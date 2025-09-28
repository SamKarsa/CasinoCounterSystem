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

            authController = new AuthController();

            SetupEvents();

            SetupControls();
        }

        private void SetupEvents()
        {
            button_join.Click += Button_join_Click;
            textbox_user.KeyPress += TextBox_KeyPress;
            textbox_password.KeyPress += TextBox_KeyPress;
            link_password.LinkClicked += link_password_LinkClicked;
        }

        private void SetupControls()
        {
            textbox_password.PasswordChar = '*';
            textbox_user.Focus();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
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

                button_join.Enabled = false;
                button_join.Text = "Authenticating...";
                this.Cursor = Cursors.WaitCursor;

                User? authenticatedUser = authController.AuthenticateUser(
                    textbox_user.Text.Trim(),
                    textbox_password.Text);

                if (authenticatedUser != null)
                {
                    SessionManager.SetCurrentUser(authenticatedUser);
                    MessageBox.Show($"Welcome, {authenticatedUser.UserName}!\nRole: {authenticatedUser.Role?.RoleName}",
                                  "Login Successful",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    this.Hide();
                    MainForm mainForm = new MainForm();

                    mainForm.FormClosed += (s, args) =>
                    {
                        SessionManager.Logout();   
                        this.Show();               
                        textbox_user.Clear();
                        textbox_password.Clear();   
                        textbox_user.Focus();      
                    };

                    mainForm.Show(this);
                }
                else
                {
                    MessageBox.Show("Invalid username or password.\nPlease try again.",
                                  "Authentication Failed",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
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
                button_join.Enabled = true;
                button_join.Text = "Join";
                this.Cursor = Cursors.Default;
            }
        }
    }
}
