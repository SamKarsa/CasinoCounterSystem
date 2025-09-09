using CasinoCounterSystem.Controller;
using CasinoCounterSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasinoCounterSystem.View
{
    public partial class FrmLogin : Form
    {
        private AuthController authController;

        public FrmLogin()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Inicializar controlador
            authController = new AuthController();

            // Configurar eventos
            SetupEvents();

            // Configurar controles
            SetupControls();
        }

        private void SetupEvents()
        {
            // Evento del botón de login
            button_join.Click += Button_join_Click;

            // Eventos para presionar Enter
            textbox_user.KeyPress += TextBox_KeyPress;
            textbox_password.KeyPress += TextBox_KeyPress;

            // Evento para el link de forgot password
            link_password.LinkClicked += link_password_LinkClicked;
        }

        private void SetupControls()
        {
            // Configurar el textbox de contraseña para que oculte el texto
            textbox_password.PasswordChar = '*';

            // Establecer el foco en el campo de usuario
            textbox_user.Focus();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si se presiona Enter, intentar hacer login
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PerformLogin();
            }
        }

        private void Button_join_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void link_password_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact your system administrator to reset your password.",
                          "Password Recovery",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void PerformLogin()
        {
            try
            {
                // Validar campos vacíos
                if (string.IsNullOrWhiteSpace(textbox_user.Text))
                {
                    MessageBox.Show("Please enter your username.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textbox_user.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textbox_password.Text))
                {
                    MessageBox.Show("Please enter your password.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textbox_password.Focus();
                    return;
                }

                // Deshabilitar el botón mientras se procesa
                button_join.Enabled = false;
                button_join.Text = "Authenticating...";
                this.Cursor = Cursors.WaitCursor;

                // Intentar autenticación
                User? authenticatedUser = authController.AuthenticateUser(
                    textbox_user.Text.Trim(),
                    textbox_password.Text);

                if (authenticatedUser != null)
                {
                    // Login exitoso
                    SessionManager.SetCurrentUser(authenticatedUser);

                    // Mostrar mensaje de bienvenida
                    MessageBox.Show($"Welcome, {authenticatedUser.UserName}!\nRole: {authenticatedUser.Role?.RoleName}",
                                  "Login Successful",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    // Abrir el formulario principal
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.FormClosed += (s, args) =>
                    {
                        // Cuando se cierre el formulario principal, cerrar la aplicación
                        SessionManager.Logout();
                        Application.Exit();
                    };
                    mainForm.Show();
                }
                else
                {
                    // Login fallido
                    MessageBox.Show("Invalid username or password.\nPlease try again.",
                                  "Authentication Failed",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);

                    // Limpiar campos
                    textbox_password.Clear();
                    textbox_user.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login:\n{ex.Message}",
                              "Login Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            finally
            {
                // Rehabilitar el botón
                button_join.Enabled = true;
                button_join.Text = "Join";
                this.Cursor = Cursors.Default;
            }
        }
    }
}
