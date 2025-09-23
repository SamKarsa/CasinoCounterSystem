using CasinoCounterSystem.Controller;
using CasinoCounterSystem.Model;
using CasinoCounterSystem.View.CounterRecord;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CounterRecordModel = CasinoCounterSystem.Model.CounterRecord;
using RouteModel = CasinoCounterSystem.Model.Route;

namespace CasinoCounterSystem.View
{
    public partial class FrmCounterRecord : Form
    {
        private bool isEditMode = false;
        private int? editRecordId = null;

        private readonly MachineController machineController = new MachineController();
        private readonly RouteController routeController = new RouteController();
        private readonly CounterRecordController counterRecordController = new CounterRecordController();
        public event EventHandler<CounterRecordSavedEventArgs>? RecordSaved;

        public FrmCounterRecord()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.AutoScaleMode = AutoScaleMode.None;

            button_join.Click += ButtonJoin_Click;
            ButtonCancel.Click += ButtonCancel_Click;

            LoadCombos();
        }

        public FrmCounterRecord(int recordId) : this()
        {
            InitEditMode(recordId);
        }

        private void ButtonJoin_Click(object? sender, EventArgs e)
        {
            try
            {
                if (ComboBoxMachine.SelectedValue == null ||
                    string.IsNullOrWhiteSpace(TextBoxIN.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxOUT.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxTotal.Text))
                {
                    MessageBox.Show("Please fill all required fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!long.TryParse(TextBoxIN.Text.Trim(), out long counterIn) ||
                    !long.TryParse(TextBoxOUT.Text.Trim(), out long counterOut) ||
                    !decimal.TryParse(TextBoxTotal.Text.Trim(), out decimal totalDelivered))
                {
                    MessageBox.Show("IN, OUT, and TOTAL must be numeric values.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int machineId = Convert.ToInt32(ComboBoxMachine.SelectedValue);
                DateTime recordDate = DatetimePicker.Value.Date;

                if (!isEditMode)
                {
                    // INSERT
                    var record = new CounterRecordModel
                    {
                        RecordDate = recordDate,
                        CounterIn = counterIn,
                        CounterOut = counterOut,
                        TotalDelivered = totalDelivered,
                        MachineId = machineId
                    };

                    int newId = counterRecordController.InsertCounterRecord(record);
                    if (newId > 0)
                    {
                        MessageBox.Show("Counter record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecordSaved?.Invoke(this, new CounterRecordSavedEventArgs(machineId, newId));
                        TextBoxIN.Clear(); TextBoxOUT.Clear(); TextBoxTotal.Clear();
                        TextBoxIN.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Error saving record. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // UPDATE
                    var record = new CounterRecordModel
                    {
                        CounterRecordId = editRecordId!.Value,
                        RecordDate = recordDate,
                        CounterIn = counterIn,
                        CounterOut = counterOut,
                        TotalDelivered = totalDelivered,
                        MachineId = machineId   // no cambia, combos están bloqueados
                    };

                    bool ok = counterRecordController.UpdateCounterRecord(record);
                    if (ok)
                    {
                        MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecordSaved?.Invoke(this, new CounterRecordSavedEventArgs(machineId, record.CounterRecordId));
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No changes were saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombos()
        {
            var routeController = new RouteController();

            // 1) Configurar Display/Value antes del DataSource (evita eventos raros)
            ComboBoxRoute.DisplayMember = "RouteName";
            ComboBoxRoute.ValueMember = "RouteId";

            // 2) Asignar DataSource
            ComboBoxRoute.DataSource = routeController.GetAllRoutes();

            // 3) Suscribir evento (después del DataSource para evitar doble disparo)
            ComboBoxRoute.SelectedIndexChanged -= ComboBoxRoute_SelectedIndexChanged;
            ComboBoxRoute.SelectedIndexChanged += ComboBoxRoute_SelectedIndexChanged;

            // 4) Poblar máquinas inmediatamente para la ruta inicialmente seleccionada
            PopulateMachinesForSelectedRoute();
        }

        private void ComboBoxRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateMachinesForSelectedRoute();
        }

        private void PopulateMachinesForSelectedRoute()
        {
            // A veces SelectedValue aún es un DataRowView en el primer bind,
            // así que usamos un fallback con SelectedItem.
            int? routeId = null;

            if (ComboBoxRoute.SelectedValue is int v)
                routeId = v;
            else if (ComboBoxRoute.SelectedItem is RouteModel r) // tu clase de modelo
                routeId = r.RouteId;

            if (routeId == null)
            {
                ComboBoxMachine.DataSource = null;
                return;
            }

            var machineController = new MachineController();
            var machines = machineController.GetMachinesByRoute(routeId.Value);

            // IMPORTANTE: asegura Display/Value antes de DataSource
            ComboBoxMachine.DisplayMember = "NumberMachine";
            ComboBoxMachine.ValueMember = "MachineId";
            ComboBoxMachine.DataSource = machines;

            // Selecciona la primera máquina si hay
            if (ComboBoxMachine.Items.Count > 0)
                ComboBoxMachine.SelectedIndex = 0;
        }

        private void InitEditMode(int recordId)
        {
            isEditMode = true;
            editRecordId = recordId;

            // UI
            uiLabel1.Text = "✏️ Edit Counter Record";
            button_join.Text = "💾 Save";

            // Cargar registro existente
            var existing = counterRecordController.GetCounterRecordById(recordId);
            if (existing == null)
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar combos con la ruta y máquina del registro
            // (aprovechamos los métodos que ya tenés)
            var machine = machineController.GetMachineById(existing.MachineId);
            var routeId = machine?.RouteId ?? 0;

            // Asegura DataSource de rutas
            ComboBoxRoute.DisplayMember = "RouteName";
            ComboBoxRoute.ValueMember = "RouteId";
            ComboBoxRoute.DataSource = routeController.GetAllRoutes();

            ComboBoxRoute.SelectedValue = routeId;
            PopulateMachinesForSelectedRoute();    
            ComboBoxMachine.SelectedValue = existing.MachineId;

            // Bloquear cambios de ruta/máquina en edición
            ComboBoxRoute.Enabled = false;
            ComboBoxMachine.Enabled = false;

            // Prefill de campos editables
            DatetimePicker.Value = existing.RecordDate;
            TextBoxIN.Text = existing.CounterIn.ToString();
            TextBoxOUT.Text = existing.CounterOut.ToString();
            TextBoxTotal.Text = existing.TotalDelivered.ToString("0");

        }

    }
}
