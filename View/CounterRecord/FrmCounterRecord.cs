using CasinoCounterSystem.Controller;
using CasinoCounterSystem.Model;
using CasinoCounterSystem.View.CounterRecord;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

            this.AcceptButton = button_join;

            DatetimePicker.Value = DateTime.Today;
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
                    MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!long.TryParse(TextBoxIN.Text.Trim(), out long counterIn) ||
                    !long.TryParse(TextBoxOUT.Text.Trim(), out long counterOut) ||
                    !decimal.TryParse(TextBoxTotal.Text.Trim(), out decimal totalDelivered))
                {
                    MessageBox.Show("Los valores de IN, OUT y TOTAL deben ser numéricos.", "Validación ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int machineId = Convert.ToInt32(ComboBoxMachine.SelectedValue);
                DateTime recordDate = DatetimePicker.Value.Date;

                if (!isEditMode)
                {
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
                        MessageBox.Show("¡Registro de contador agregado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecordSaved?.Invoke(this, new CounterRecordSavedEventArgs(machineId, newId));
                        TextBoxIN.Clear(); TextBoxOUT.Clear(); TextBoxTotal.Clear();
                        TextBoxIN.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el registro. Inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var record = new CounterRecordModel
                    {
                        CounterRecordId = editRecordId!.Value,
                        RecordDate = recordDate,
                        CounterIn = counterIn,
                        CounterOut = counterOut,
                        TotalDelivered = totalDelivered,
                        MachineId = machineId  
                    };

                    bool ok = counterRecordController.UpdateCounterRecord(record);
                    if (ok)
                    {
                        MessageBox.Show("¡Registro actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecordSaved?.Invoke(this, new CounterRecordSavedEventArgs(machineId, record.CounterRecordId));
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se guardaron cambios.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombos()
        {
            var routeController = new RouteController();

            ComboBoxRoute.DisplayMember = "RouteName";
            ComboBoxRoute.ValueMember = "RouteId";

            ComboBoxRoute.DataSource = routeController.GetAllRoutes();

            ComboBoxRoute.SelectedIndexChanged -= ComboBoxRoute_SelectedIndexChanged!;
            ComboBoxRoute.SelectedIndexChanged += ComboBoxRoute_SelectedIndexChanged!;

            PopulateMachinesForSelectedRoute();
        }

        private void ComboBoxRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateMachinesForSelectedRoute();
        }

        private void PopulateMachinesForSelectedRoute()
        {
            int? routeId = null;

            if (ComboBoxRoute.SelectedValue is int v)
                routeId = v;
            else if (ComboBoxRoute.SelectedItem is RouteModel r) 
                routeId = r.RouteId;

            if (routeId == null)
            {
                ComboBoxMachine.DataSource = null;
                return;
            }

            var machineController = new MachineController();
            var machines = machineController.GetMachinesByRoute(routeId.Value);

            ComboBoxMachine.DisplayMember = "NumberMachine";
            ComboBoxMachine.ValueMember = "MachineId";
            ComboBoxMachine.DataSource = machines;

            if (ComboBoxMachine.Items.Count > 0)
                ComboBoxMachine.SelectedIndex = 0;
        }

        private void InitEditMode(int recordId)
        {
            isEditMode = true;
            editRecordId = recordId;

            uiLabel1.Text = "✏️ Editar Registro";
            button_join.Text = "💾 Guardar";

            var existing = counterRecordController.GetCounterRecordById(recordId);
            if (existing == null)
            {
                MessageBox.Show("Registro no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var machine = machineController.GetMachineById(existing.MachineId);
            var routeId = machine?.RouteId ?? 0;

            ComboBoxRoute.DisplayMember = "RouteName";
            ComboBoxRoute.ValueMember = "RouteId";
            ComboBoxRoute.DataSource = routeController.GetAllRoutes();

            ComboBoxRoute.SelectedValue = routeId;
            PopulateMachinesForSelectedRoute();    
            ComboBoxMachine.SelectedValue = existing.MachineId;

            ComboBoxRoute.Enabled = false;
            ComboBoxMachine.Enabled = false;

            DatetimePicker.Value = existing.RecordDate;
            TextBoxIN.Text = existing.CounterIn.ToString();
            TextBoxOUT.Text = existing.CounterOut.ToString();
            TextBoxTotal.Text = existing.TotalDelivered.ToString("0");

        }

    }
}
