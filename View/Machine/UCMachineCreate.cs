using CasinoCounterSystem.Controller;
using CasinoCounterSystem.Model;
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
using InfoMachineModel = CasinoCounterSystem.Model.InfoMachine;
using MachineModel = CasinoCounterSystem.Model.Machine;

namespace CasinoCounterSystem.View.Machine
{
    public partial class UCMachineCreate : UserControl
    {

        public event EventHandler? CancelClicked;
        public event EventHandler? MachineCreated;
        private readonly MachineController machineController = new MachineController();
        public event EventHandler? MachineUpdated;
        private bool isEditMode = false;
        private int? editMachineId = null;

        public UCMachineCreate()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            btnCancelRoute.Click += BtnCancel_Click!;
            btnSaveRoute.Click += BtnSave_Click!;

            this.Load += (_, __) => RefreshWatermarks();

            LoadCombos();
        }

        private void RefreshWatermarks()
        {
            ForceWatermark(textBoxNumMachine);
            ForceWatermark(textBoxNameClient);
            ForceWatermark(textBoxPhone);
            ForceWatermark(textBoxAddress);
            ForceWatermark(TextBoxIn);
            ForceWatermark(TextBoxOut);
        }

        private static void ForceWatermark(Sunny.UI.UITextBox tb)
        {
            tb.StyleCustomMode = true;

            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = " ";
                tb.Clear();
                tb.Invalidate();           
                tb.Update();               
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // ---------- Normalización ----------
                // N° máquina: trim + MAYÚSCULAS
                var numberMachine = (textBoxNumMachine.Text ?? "").Trim().ToUpperInvariant();
                textBoxNumMachine.Text = numberMachine;

                // Nombre cliente: TitleCase
                var clientName = ToTitleCase(textBoxNameClient.Text);
                textBoxNameClient.Text = clientName;

                // Teléfono (opcional):
                // - si está vacío => null
                // - si tiene algo => solo dígitos y largo 10
                string? phoneDigits = null;
                var phoneRaw = textBoxPhone.Text ?? "";
                var phoneClean = OnlyDigits(phoneRaw);
                if (!string.IsNullOrWhiteSpace(phoneRaw))
                {
                    if (phoneClean.Length != 10)
                    {
                        MessageBox.Show("El número de teléfono debe tener 10 dígitos (o déjalo vacío).",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxPhone.Focus();
                        textBoxPhone.SelectAll();
                        return;
                    }
                    phoneDigits = phoneClean;
                    textBoxPhone.Text = phoneDigits; // normaliza lo visible
                }

                // Dirección: trim (si quieres, puedes aplicar TitleCase también)
                var address = (textBoxAddress.Text ?? "").Trim();
                // address = ToTitleCase(address); // opcional

                // ---------- Requeridos ----------
                if (comboBoxRoute.SelectedItem == null ||
                    comboBoxCoinType.SelectedItem == null ||
                    comboBoxMachineType.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(numberMachine))
                {
                    MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si es creación, IN/OUT obligatorios y numéricos
                int counterIn = 0, counterOut = 0;
                if (!isEditMode)
                {
                    if (string.IsNullOrWhiteSpace(TextBoxIn.Text) ||
                        string.IsNullOrWhiteSpace(TextBoxOut.Text))
                    {
                        MessageBox.Show("Los valores de instalación IN y OUT son obligatorios.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(TextBoxIn.Text.Trim(), out counterIn) ||
                        !int.TryParse(TextBoxOut.Text.Trim(), out counterOut))
                    {
                        MessageBox.Show("Los valores de instalación IN y OUT tienen que ser numeros", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // ---------- Duplicados (case-insensitive) ----------
                bool exists = machineController.NumberExists(numberMachine, isEditMode ? editMachineId : null);
                if (exists)
                {
                    MessageBox.Show("Ese número de máquina ya existe. Por favor, elige otro.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxNumMachine.Focus();
                    textBoxNumMachine.SelectAll();
                    return;
                }

                // ---------- Construcción del modelo ----------
                var machine = new MachineModel
                {
                    NumberMachine = numberMachine,
                    RouteId = (int)comboBoxRoute.SelectedValue,
                    CoinTypeId = (int)comboBoxCoinType.SelectedValue,
                    TypeMachineId = (int)comboBoxMachineType.SelectedValue,
                    InfoMachine = new InfoMachineModel
                    {
                        NameClient = clientName,
                        Phone = phoneDigits,   // <- puede ser null
                        Address = address
                    }
                };

                // ---------- Insert / Update ----------
                if (!isEditMode)
                {
                    int newId = machineController.InsertMachine(machine, counterIn, counterOut);
                    if (newId > 0)
                    {
                        MessageBox.Show("¡Máquina creada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MachineCreated?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la máquina. Inténtalo de nuevo.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (!editMachineId.HasValue)
                    {
                        MessageBox.Show("Falta el ID de la máquina para actualizar.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    machine.MachineId = editMachineId.Value;
                    machine.InfoMachine!.InfoMachineId = editMachineId.Value;

                    var success = machineController.UpdateMachine(machine);
                    if (success)
                    {
                        MessageBox.Show("¡Máquina actualizada exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MachineUpdated?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la máquina. Inténtalo de nuevo.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Microsoft.Data.Sqlite.SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                // Respaldo por si llega a escapar un UNIQUE de SQLite
                MessageBox.Show("El número de máquina ya existe.",
                    "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxNumMachine.Focus();
                textBoxNumMachine.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string OnlyDigits(string? s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            var sb = new System.Text.StringBuilder(s.Length);
            foreach (var ch in s)
                if (char.IsDigit(ch)) sb.Append(ch);
            return sb.ToString();
        }

        private static string ToTitleCase(string? s)
        {
            s ??= "";
            s = s.Trim().ToLowerInvariant();

            // TitleCase básico (en inglés). Si quieres reglas más locales, cambia la cultura.
            var ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            var result = ti.ToTitleCase(s);

            // Quita dobles espacios que ToTitleCase no arregla a veces.
            return System.Text.RegularExpressions.Regex.Replace(result, @"\s{2,}", " ");
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
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        public void InitEditMode(int machineId)
        {
            isEditMode = true;
            editMachineId = machineId;
            labelTitle.Text = "Editar Máquina";
            btnSaveRoute.Text = "💾 Guardar";
            LoadCombos();
            var mc = new MachineController();
            var m = mc.GetMachineById(machineId);
            if (m == null) return;
            textBoxNumMachine.Text = m.NumberMachine;
            comboBoxRoute.SelectedValue = m.RouteId;
            comboBoxCoinType.SelectedValue = m.CoinTypeId;
            comboBoxMachineType.SelectedValue = m.TypeMachineId;
            textBoxNameClient.Text = m.InfoMachine?.NameClient ?? "";
            textBoxPhone.Text = m.InfoMachine?.Phone ?? "";
            textBoxAddress.Text = m.InfoMachine?.Address ?? "";
            TextBoxIn.Visible = false;
            TextBoxOut.Visible = false;
        }


    }
}
