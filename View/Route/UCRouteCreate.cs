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

        // Editar ruta desde el main
        public event EventHandler? RouteUpdated;
        private bool isEditMode = false;
        private int? editRouteId = null;
        private string? originalName;   // nombre actual antes de editar




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
                MessageBox.Show("Please enter a route name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxRoute.Focus();
                return;
            }

            try
            {
                // Solo chequea duplicado si es alta o si en edición el nombre cambió
                bool mustCheckDuplicate = !isEditMode ||
                    !string.Equals(name, originalName ?? string.Empty, StringComparison.OrdinalIgnoreCase);

                if (mustCheckDuplicate && routeController.RouteNameExists(name))
                {
                    MessageBox.Show("That route name already exists. Please choose another.",
                        "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxRoute.Focus();
                    textBoxRoute.SelectAll();
                    return;
                }

                if (!isEditMode)
                {
                    // INSERT
                    var ok = routeController.InsertRoute(name);
                    if (!ok)
                    {
                        MessageBox.Show("The route could not be saved. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Route created successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RouteCreated?.Invoke(this, EventArgs.Empty);

                    // opcional: limpiar y enfocar
                    // textBoxRoute.Clear();
                    // textBoxRoute.Focus();
                }
                else
                {
                    // UPDATE
                    if (editRouteId == null)
                    {
                        MessageBox.Show("No route selected to edit.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var ok = routeController.UpdateRoute(editRouteId.Value, name);
                    if (!ok)
                    {
                        MessageBox.Show("The route could not be updated. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Route updated successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RouteUpdated?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Claves únicas (por si otro proceso insertó el mismo nombre entre chequeo y guardado)
                MessageBox.Show("That route name already exists (database constraint). Please choose another.",
                    "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxRoute.Focus();
                textBoxRoute.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Método público para poner el UC en modo edición
        public void InitEditMode(int routeId)
        {
            isEditMode = true;
            editRouteId = routeId;

            labelTitle.Text = "Edit Route";
            btnSaveRoute.Text = "💾 Save";

            var route = routeController.GetRouteById(routeId); // reutiliza el existente
            if (route != null)
            {
                textBoxRoute.Text = route.RouteName;
                originalName = route.RouteName;   // <-- AQUÍ la guardas
            }
            else
            {
                originalName = null; // forzará el chequeo de duplicado si no pudo cargar
            }
        }


    }
}
