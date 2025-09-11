using CasinoCounterSystem.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasinoCounterSystem.View.Route
{
    public partial class UCRouteCreate : UserControl
    {
        // Eventos para comunicarse con el MainForm
        public event EventHandler? CancelClicked;
        public event EventHandler? RouteCreated;

        private readonly RouteController routeController = new RouteController();

        public UCRouteCreate()
        {
            InitializeComponent();

            // SOLO esta línea
            this.AutoScaleMode = AutoScaleMode.None;

            // Suscribir eventos a los botones
            btnCancelRoute.Click += BtnCancel_Click!;
            btnSaveRoute.Click += BtnSave_Click!;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Disparar el evento para volver al Home
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var name = (textBoxRoute.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a route name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxRoute.Focus();
                return;
            }

            try
            {
                // Validación previa para mejor UX
                if (routeController.RouteNameExists(name))
                {
                    MessageBox.Show("That route name already exists. Please choose another.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxRoute.Focus();
                    textBoxRoute.SelectAll();
                    return;
                }

                // Insertar
                var ok = routeController.InsertRoute(name);
                if (!ok)
                {
                    MessageBox.Show("The route could not be saved. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Éxito
                MessageBox.Show("Route created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RouteCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // 2627: Violation of PRIMARY KEY or UNIQUE KEY
                // 2601: Cannot insert duplicate key row in object with unique index
                MessageBox.Show("That route name already exists (database constraint). Please choose another.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxRoute.Focus();
                textBoxRoute.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
