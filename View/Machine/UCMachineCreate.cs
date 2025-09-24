using CasinoCounterSystem.Controller;
using CasinoCounterSystem.Model;
using MachineModel = CasinoCounterSystem.Model.Machine;
using InfoMachineModel = CasinoCounterSystem.Model.InfoMachine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasinoCounterSystem.View.Machine
{
    public partial class UCMachineCreate : UserControl
    {

        // Eventos para comunicarse con el MainForm
        public event EventHandler? CancelClicked;
        public event EventHandler? MachineCreated;

        private readonly MachineController machineController = new MachineController();

        // Editar máquina desde el main
        public event EventHandler? MachineUpdated;

        private bool isEditMode = false;
        private int? editMachineId = null;

        public UCMachineCreate()
        {
            InitializeComponent();

            // SOLO esta línea
            this.AutoScaleMode = AutoScaleMode.None;

            // Suscribir eventos a los botones
            btnCancelRoute.Click += BtnCancel_Click!;
            btnSaveRoute.Click += BtnSave_Click!;

            LoadCombos();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Validación común (sin contadores aún)
                if (comboBoxRoute.SelectedItem == null ||
                    comboBoxCoinType.SelectedItem == null ||
                    comboBoxMachineType.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(textBoxNumMachine.Text))
                {
                    MessageBox.Show("Please fill all required fields.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2) Si es CREACIÓN, validar y convertir IN/OUT
                int counterIn = 0, counterOut = 0;
                if (!isEditMode)
                {
                    if (string.IsNullOrWhiteSpace(TextBoxIn.Text) ||
                        string.IsNullOrWhiteSpace(TextBoxOut.Text))
                    {
                        MessageBox.Show("Installation IN and OUT are required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(TextBoxIn.Text.Trim(), out counterIn) ||
                        !int.TryParse(TextBoxOut.Text.Trim(), out counterOut))
                    {
                        MessageBox.Show("Installation IN and OUT must be numbers.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 3) Armar objeto Machine (común a ambos modos)
                var machine = new MachineModel
                {
                    NumberMachine = textBoxNumMachine.Text.Trim(),
                    RouteId = (int)comboBoxRoute.SelectedValue,
                    CoinTypeId = (int)comboBoxCoinType.SelectedValue,
                    TypeMachineId = (int)comboBoxMachineType.SelectedValue,
                    InfoMachine = new InfoMachineModel
                    {
                        // En edición se sobreescribe InfoMachineId, en creación lo pone el controller
                        NameClient = textBoxNameClient.Text.Trim(),
                        Phone = textBoxPhone.Text.Trim(),
                        Address = textBoxAddress.Text.Trim()
                    }
                };

                // 4) Crear o Actualizar
                if (!isEditMode)
                {
                    // INSERT (con IN/OUT iniciales)
                    int newId = machineController.InsertMachine(machine, counterIn, counterOut);
                    if (newId > 0)
                    {
                        MessageBox.Show("Machine created successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MachineCreated?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Error saving machine. Try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // UPDATE (sin tocar counters)
                    if (!editMachineId.HasValue)
                    {
                        MessageBox.Show("Missing machine id to update.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    machine.MachineId = editMachineId.Value;
                    machine.InfoMachine!.InfoMachineId = editMachineId.Value;

                    var success = machineController.UpdateMachine(machine);
                    if (success)
                    {
                        MessageBox.Show("Machine updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MachineUpdated?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Error updating machine. Try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCombos()
        {
            var routeController = new RouteController();
            comboBoxRoute.DataSource = routeController.GetAllRoutes();
            comboBoxRoute.DisplayMember = "RouteName";
            comboBoxRoute.ValueMember = "RouteId";

            var typeController = new TypeMachineController();  
            comboBoxMachineType.DataSource = typeController.GetAllTypeMachine();
            comboBoxMachineType.DisplayMember = "nameTypeMachine";
            comboBoxMachineType.ValueMember = "typeMachineId";

            var coinController = new CoinTypeController();     
            comboBoxCoinType.DataSource = coinController.GetAllCoins();
            comboBoxCoinType.DisplayMember = "numCoin";
            comboBoxCoinType.ValueMember = "coinTypeId";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Disparar el evento para volver al Home
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        public void InitEditMode(int machineId)
        {
            isEditMode = true;
            editMachineId = machineId;

            labelTitle.Text = "Edit Machine";
            btnSaveRoute.Text = "💾 Save";

            // Cargar combos (si no se cargaron)
            LoadCombos();

            var mc = new MachineController();
            var m = mc.GetMachineById(machineId);
            if (m == null) return;

            // Prefill
            textBoxNumMachine.Text = m.NumberMachine;
            comboBoxRoute.SelectedValue = m.RouteId;
            comboBoxCoinType.SelectedValue = m.CoinTypeId;
            comboBoxMachineType.SelectedValue = m.TypeMachineId;

            textBoxNameClient.Text = m.InfoMachine?.NameClient ?? "";
            textBoxPhone.Text = m.InfoMachine?.Phone ?? "";
            textBoxAddress.Text = m.InfoMachine?.Address ?? "";

            // Ocultar / deshabilitar campos de instalación (IN/OUT) en edición
            TextBoxIn.Visible = false;
            TextBoxOut.Visible = false;
        }
    }
}
