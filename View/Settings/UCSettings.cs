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

namespace CasinoCounterSystem.View.Settings
{
    public partial class UCSettings : UserControl
    {
        private readonly UserController _userController = new UserController();

        public UCSettings()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;

            btnSaveAdmin.Click += BtnSaveAdmin_Click;
            btnResetOperator.Click += BtnResetOperator_Click;

            this.Load += (_, __) => RefreshWatermarks();
        }

        private void RefreshWatermarks()
        {
            ForceWatermark(textBoxAdminOldPassword);
            ForceWatermark(textBoxAdminNewPassword);
            ForceWatermark(textBoxAdminNewPasswordConfirm);
            ForceWatermark(textBoxOpeNewPassword);
            ForceWatermark(textBoxOpeNewPasswordConfirm);
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

        private void BtnSaveAdmin_Click(object? sender, EventArgs e)
        {
            // Seguridad: solo admin puede tocar esto
            if (!SessionManager.IsAdmin)
            {
                MessageBox.Show("Solo el Administrador puede cambiar esta contraseña.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var oldPwd = textBoxAdminOldPassword.Text.Trim();
            var newPwd = textBoxAdminNewPassword.Text.Trim();
            var newPwd2 = textBoxAdminNewPasswordConfirm.Text.Trim();

            // Validaciones mínimas
            if (string.IsNullOrEmpty(oldPwd) || string.IsNullOrEmpty(newPwd) || string.IsNullOrEmpty(newPwd2))
            {
                MessageBox.Show("Completa todos los campos del Administrador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPwd.Length < 6)
            {
                MessageBox.Show("La nueva contraseña del Administrador debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.Equals(newPwd, newPwd2, StringComparison.Ordinal))
            {
                MessageBox.Show("La nueva contraseña y su confirmación (Administrador) no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.Equals(oldPwd, newPwd, StringComparison.Ordinal))
            {
                MessageBox.Show("La nueva contraseña del Administrador no puede ser igual a la actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ejecutar cambio
            var ok = _userController.ChangeMyPassword(SessionManager.UserId, oldPwd, newPwd);
            if (ok)
            {
                MessageBox.Show("Contraseña del Administrador actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxAdminOldPassword.Text = "";
                textBoxAdminNewPassword.Text = "";
                textBoxAdminNewPasswordConfirm.Text = "";
            }
            else
            {
                MessageBox.Show("La contraseña actual del Administrador es incorrecta o no se pudo actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnResetOperator_Click(object? sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin)
            {
                MessageBox.Show("Solo el Administrador puede restablecer la contraseña del Operador.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newPwd = textBoxOpeNewPassword.Text.Trim();
            var newPwd2 = textBoxOpeNewPasswordConfirm.Text.Trim();

            if (string.IsNullOrEmpty(newPwd) || string.IsNullOrEmpty(newPwd2))
            {
                MessageBox.Show("Completa ambos campos del Operador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPwd.Length < 6)
            {
                MessageBox.Show("La nueva contraseña del Operador debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.Equals(newPwd, newPwd2, StringComparison.Ordinal))
            {
                MessageBox.Show("La nueva contraseña y su confirmación (Operador) no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Deseas restablecer la contraseña del Operador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var ok = _userController.AdminResetOperatorPassword(newPwd);
            if (ok)
            {
                MessageBox.Show("Contraseña del Operador actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxOpeNewPassword.Text = "";
                textBoxOpeNewPasswordConfirm.Text = "";
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la contraseña del Operador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
