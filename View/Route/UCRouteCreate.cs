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

        public event EventHandler? CancelClicked;
        public event EventHandler? RouteCreated;
        private readonly RouteController routeController = new RouteController();
        public event EventHandler? RouteUpdated;
        private bool isEditMode = false;
        private int? editRouteId = null;
        private string? originalName;  

        public UCRouteCreate()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;

            btnCancelRoute.Click += BtnCancel_Click!;
            btnSaveRoute.Click += BtnSave_Click!;

            this.Load += (_, __) => RefreshWatermarks();
        }

        private void RefreshWatermarks()
        {
            ForceWatermark(textBoxRoute);
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {

            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var name = (textBoxRoute.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Por favor, ingresa un nombre de ruta.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxRoute.Focus();
                return;
            }

            try
            {

                bool mustCheckDuplicate = !isEditMode ||
                    !string.Equals(name, originalName ?? string.Empty, StringComparison.OrdinalIgnoreCase);

                if (mustCheckDuplicate && routeController.RouteNameExists(name))
                {
                    MessageBox.Show("Ese nombre de ruta ya existe. Por favor, elige otro.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxRoute.Focus();
                    textBoxRoute.SelectAll();
                    return;
                }

                if (!isEditMode)
                {

                    var ok = routeController.InsertRoute(name);
                    if (!ok)
                    {
                        MessageBox.Show("No se pudo guardar la ruta. Por favor, inténtalo de nuevo.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("¡Ruta creada exitosamente!",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RouteCreated?.Invoke(this, EventArgs.Empty);

                }
                else
                {

                    if (editRouteId == null)
                    {
                        MessageBox.Show("No se ha seleccionado ninguna ruta para editar.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var ok = routeController.UpdateRoute(editRouteId.Value, name);
                    if (!ok)
                    {
                        MessageBox.Show("No se pudo actualizar la ruta. Por favor, inténtalo de nuevo.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("¡Ruta actualizada exitosamente!",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RouteUpdated?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Microsoft.Data.Sqlite.SqliteException ex) when (ex.SqliteErrorCode == 19)
            {

                MessageBox.Show("Ese nombre de ruta ya existe. Por favor, elige otro.",
                    "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxRoute.Focus();
                textBoxRoute.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InitEditMode(int routeId)
        {
            isEditMode = true;
            editRouteId = routeId;

            labelTitle.Text = "Editar Ruta";
            btnSaveRoute.Text = "💾 Guardar";

            var route = routeController.GetRouteById(routeId); 
            if (route != null)
            {
                textBoxRoute.Text = route.RouteName;
                originalName = route.RouteName; 
            }
            else
            {
                originalName = null; 
            }
        }
    }
}
