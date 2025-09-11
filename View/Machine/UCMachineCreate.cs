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
                // 1. Validar campos mínimos
                if (comboBoxRoute.SelectedItem == null ||
                    comboBoxCoinType.SelectedItem == null ||
                    comboBoxMachineType.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(textBoxNumMachine.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxIn.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxOut.Text))
                {
                    MessageBox.Show("Please fill all required fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Convertir contadores
                if (!int.TryParse(TextBoxIn.Text.Trim(), out int counterIn) ||
                    !int.TryParse(TextBoxOut.Text.Trim(), out int counterOut))
                {
                    MessageBox.Show("Installation IN and OUT must be numbers.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Crear objeto Machine
                var machine = new MachineModel
                {
                    NumberMachine = textBoxNumMachine.Text.Trim(),
                    RouteId = (int)comboBoxRoute.SelectedValue,       // asegúrate de que el DataSource devuelva int
                    CoinTypeId = (int)comboBoxCoinType.SelectedValue, // idem
                    TypeMachineId = (int)comboBoxMachineType.SelectedValue,
                    InfoMachine = new InfoMachine
                    {
                        NameClient = textBoxNameClient.Text.Trim(),
                        Phone = textBoxPhone.Text.Trim(),
                        Address = textBoxAddress.Text.Trim()
                    }
                };

                // 4. Insertar en DB
                int newId = machineController.InsertMachine(machine, counterIn, counterOut);

                if (newId > 0)
                {
                    MessageBox.Show("Machine created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MachineCreated?.Invoke(this, EventArgs.Empty); // Notificar al MainForm
                }
                else
                {
                    MessageBox.Show("Error saving machine. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
