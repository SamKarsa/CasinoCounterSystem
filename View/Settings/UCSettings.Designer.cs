namespace CasinoCounterSystem.View.Settings
{
    partial class UCSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitle = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            line = new Sunny.UI.UILine();
            uiLabel2 = new Sunny.UI.UILabel();
            textBoxAdminOldPassword = new Sunny.UI.UITextBox();
            textBoxAdminNewPassword = new Sunny.UI.UITextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnSaveAdmin = new Sunny.UI.UIButton();
            btnResetOperator = new Sunny.UI.UIButton();
            textBoxOpeNewPassword = new Sunny.UI.UITextBox();
            uiLabel3 = new Sunny.UI.UILabel();
            textBoxAdminNewPasswordConfirm = new Sunny.UI.UITextBox();
            textBoxOpeNewPasswordConfirm = new Sunny.UI.UITextBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Britannic Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Navy;
            labelTitle.Location = new Point(57, 34);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(337, 60);
            labelTitle.TabIndex = 16;
            labelTitle.Text = "Configuración";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("Britannic Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uiLabel1.ForeColor = Color.Black;
            uiLabel1.Location = new Point(57, 111);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(530, 60);
            uiLabel1.TabIndex = 18;
            uiLabel1.Text = "Cambiar contraseñas";
            // 
            // line
            // 
            line.BackColor = Color.Transparent;
            line.Font = new Font("Microsoft Sans Serif", 12F);
            line.ForeColor = Color.FromArgb(48, 48, 48);
            line.LineColor = Color.Black;
            line.Location = new Point(57, 147);
            line.MinimumSize = new Size(1, 1);
            line.Name = "line";
            line.Size = new Size(850, 10);
            line.TabIndex = 19;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("Britannic Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uiLabel2.ForeColor = Color.Black;
            uiLabel2.Location = new Point(84, 191);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(188, 35);
            uiLabel2.TabIndex = 20;
            uiLabel2.Text = "Administrador";
            // 
            // textBoxAdminOldPassword
            // 
            textBoxAdminOldPassword.ButtonRectColor = Color.Black;
            textBoxAdminOldPassword.ButtonRectHoverColor = Color.Black;
            textBoxAdminOldPassword.ButtonRectPressColor = Color.Black;
            textBoxAdminOldPassword.ButtonStyleInherited = false;
            textBoxAdminOldPassword.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxAdminOldPassword.Location = new Point(84, 241);
            textBoxAdminOldPassword.Margin = new Padding(4, 5, 4, 5);
            textBoxAdminOldPassword.MinimumSize = new Size(1, 16);
            textBoxAdminOldPassword.Name = "textBoxAdminOldPassword";
            textBoxAdminOldPassword.Padding = new Padding(12, 5, 12, 5);
            textBoxAdminOldPassword.PasswordChar = '•';
            textBoxAdminOldPassword.Radius = 6;
            textBoxAdminOldPassword.RectColor = Color.Navy;
            textBoxAdminOldPassword.RectSize = 2;
            textBoxAdminOldPassword.ShowText = false;
            textBoxAdminOldPassword.Size = new Size(341, 50);
            textBoxAdminOldPassword.TabIndex = 21;
            textBoxAdminOldPassword.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxAdminOldPassword.Watermark = "Ingresa la contraseña actual";
            textBoxAdminOldPassword.WatermarkActiveColor = Color.DarkGray;
            textBoxAdminOldPassword.WatermarkColor = SystemColors.GrayText;
            // 
            // textBoxAdminNewPassword
            // 
            textBoxAdminNewPassword.ButtonRectColor = Color.Black;
            textBoxAdminNewPassword.ButtonRectHoverColor = Color.Black;
            textBoxAdminNewPassword.ButtonRectPressColor = Color.Black;
            textBoxAdminNewPassword.ButtonStyleInherited = false;
            textBoxAdminNewPassword.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxAdminNewPassword.Location = new Point(84, 301);
            textBoxAdminNewPassword.Margin = new Padding(4, 5, 4, 5);
            textBoxAdminNewPassword.MinimumSize = new Size(1, 16);
            textBoxAdminNewPassword.Name = "textBoxAdminNewPassword";
            textBoxAdminNewPassword.Padding = new Padding(12, 5, 12, 5);
            textBoxAdminNewPassword.PasswordChar = '•';
            textBoxAdminNewPassword.Radius = 6;
            textBoxAdminNewPassword.RectColor = Color.Navy;
            textBoxAdminNewPassword.RectSize = 2;
            textBoxAdminNewPassword.ShowText = false;
            textBoxAdminNewPassword.Size = new Size(341, 50);
            textBoxAdminNewPassword.TabIndex = 22;
            textBoxAdminNewPassword.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxAdminNewPassword.Watermark = "Ingresa la nueva contraseña";
            textBoxAdminNewPassword.WatermarkActiveColor = Color.DarkGray;
            textBoxAdminNewPassword.WatermarkColor = SystemColors.GrayText;
            // 
            // btnSaveAdmin
            // 
            btnSaveAdmin.BackColor = Color.White;
            btnSaveAdmin.FillColor = Color.Navy;
            btnSaveAdmin.FillColor2 = Color.Navy;
            btnSaveAdmin.FillDisableColor = Color.FromArgb(229, 231, 235);
            btnSaveAdmin.FillHoverColor = Color.FromArgb(30, 58, 138);
            btnSaveAdmin.FillPressColor = Color.FromArgb(0, 0, 102);
            btnSaveAdmin.FillSelectedColor = Color.FromArgb(30, 64, 175);
            btnSaveAdmin.Font = new Font("Microsoft Sans Serif", 12F);
            btnSaveAdmin.ForeDisableColor = Color.FromArgb(156, 163, 175);
            btnSaveAdmin.Location = new Point(84, 430);
            btnSaveAdmin.MinimumSize = new Size(1, 1);
            btnSaveAdmin.Name = "btnSaveAdmin";
            btnSaveAdmin.RectColor = Color.Navy;
            btnSaveAdmin.RectDisableColor = Color.FromArgb(209, 213, 219);
            btnSaveAdmin.RectHoverColor = Color.FromArgb(30, 58, 138);
            btnSaveAdmin.RectPressColor = Color.FromArgb(0, 0, 102);
            btnSaveAdmin.RectSelectedColor = Color.FromArgb(30, 64, 175);
            btnSaveAdmin.Size = new Size(215, 41);
            btnSaveAdmin.TabIndex = 28;
            btnSaveAdmin.Text = "🔒 Cambiar mi contraseña";
            btnSaveAdmin.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnResetOperator
            // 
            btnResetOperator.BackColor = Color.White;
            btnResetOperator.FillColor = Color.Navy;
            btnResetOperator.FillColor2 = Color.Navy;
            btnResetOperator.FillDisableColor = Color.FromArgb(229, 231, 235);
            btnResetOperator.FillHoverColor = Color.FromArgb(30, 58, 138);
            btnResetOperator.FillPressColor = Color.FromArgb(0, 0, 102);
            btnResetOperator.FillSelectedColor = Color.FromArgb(30, 64, 175);
            btnResetOperator.Font = new Font("Microsoft Sans Serif", 12F);
            btnResetOperator.ForeDisableColor = Color.FromArgb(156, 163, 175);
            btnResetOperator.Location = new Point(536, 370);
            btnResetOperator.MinimumSize = new Size(1, 1);
            btnResetOperator.Name = "btnResetOperator";
            btnResetOperator.RectColor = Color.Navy;
            btnResetOperator.RectDisableColor = Color.FromArgb(209, 213, 219);
            btnResetOperator.RectHoverColor = Color.FromArgb(30, 58, 138);
            btnResetOperator.RectPressColor = Color.FromArgb(0, 0, 102);
            btnResetOperator.RectSelectedColor = Color.FromArgb(30, 64, 175);
            btnResetOperator.Size = new Size(229, 41);
            btnResetOperator.TabIndex = 32;
            btnResetOperator.Text = "🔄 Restablecer del operador";
            btnResetOperator.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // textBoxOpeNewPassword
            // 
            textBoxOpeNewPassword.ButtonRectColor = Color.Black;
            textBoxOpeNewPassword.ButtonRectHoverColor = Color.Black;
            textBoxOpeNewPassword.ButtonRectPressColor = Color.Black;
            textBoxOpeNewPassword.ButtonStyleInherited = false;
            textBoxOpeNewPassword.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxOpeNewPassword.Location = new Point(536, 241);
            textBoxOpeNewPassword.Margin = new Padding(4, 5, 4, 5);
            textBoxOpeNewPassword.MinimumSize = new Size(1, 16);
            textBoxOpeNewPassword.Name = "textBoxOpeNewPassword";
            textBoxOpeNewPassword.Padding = new Padding(12, 5, 12, 5);
            textBoxOpeNewPassword.PasswordChar = '•';
            textBoxOpeNewPassword.Radius = 6;
            textBoxOpeNewPassword.RectColor = Color.Navy;
            textBoxOpeNewPassword.RectSize = 2;
            textBoxOpeNewPassword.ShowText = false;
            textBoxOpeNewPassword.Size = new Size(341, 50);
            textBoxOpeNewPassword.TabIndex = 31;
            textBoxOpeNewPassword.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxOpeNewPassword.Watermark = "Ingresa la nueva contraseña";
            textBoxOpeNewPassword.WatermarkActiveColor = Color.DarkGray;
            textBoxOpeNewPassword.WatermarkColor = SystemColors.GrayText;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("Britannic Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uiLabel3.ForeColor = Color.Black;
            uiLabel3.Location = new Point(536, 191);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(188, 35);
            uiLabel3.TabIndex = 29;
            uiLabel3.Text = "Operador";
            // 
            // textBoxAdminNewPasswordConfirm
            // 
            textBoxAdminNewPasswordConfirm.ButtonRectColor = Color.Black;
            textBoxAdminNewPasswordConfirm.ButtonRectHoverColor = Color.Black;
            textBoxAdminNewPasswordConfirm.ButtonRectPressColor = Color.Black;
            textBoxAdminNewPasswordConfirm.ButtonStyleInherited = false;
            textBoxAdminNewPasswordConfirm.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxAdminNewPasswordConfirm.Location = new Point(84, 361);
            textBoxAdminNewPasswordConfirm.Margin = new Padding(4, 5, 4, 5);
            textBoxAdminNewPasswordConfirm.MinimumSize = new Size(1, 16);
            textBoxAdminNewPasswordConfirm.Name = "textBoxAdminNewPasswordConfirm";
            textBoxAdminNewPasswordConfirm.Padding = new Padding(12, 5, 12, 5);
            textBoxAdminNewPasswordConfirm.PasswordChar = '•';
            textBoxAdminNewPasswordConfirm.Radius = 6;
            textBoxAdminNewPasswordConfirm.RectColor = Color.Navy;
            textBoxAdminNewPasswordConfirm.RectSize = 2;
            textBoxAdminNewPasswordConfirm.ShowText = false;
            textBoxAdminNewPasswordConfirm.Size = new Size(341, 50);
            textBoxAdminNewPasswordConfirm.TabIndex = 23;
            textBoxAdminNewPasswordConfirm.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxAdminNewPasswordConfirm.Watermark = "Repite la nueva contraseña";
            textBoxAdminNewPasswordConfirm.WatermarkActiveColor = Color.DarkGray;
            textBoxAdminNewPasswordConfirm.WatermarkColor = SystemColors.GrayText;
            // 
            // textBoxOpeNewPasswordConfirm
            // 
            textBoxOpeNewPasswordConfirm.ButtonRectColor = Color.Black;
            textBoxOpeNewPasswordConfirm.ButtonRectHoverColor = Color.Black;
            textBoxOpeNewPasswordConfirm.ButtonRectPressColor = Color.Black;
            textBoxOpeNewPasswordConfirm.ButtonStyleInherited = false;
            textBoxOpeNewPasswordConfirm.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxOpeNewPasswordConfirm.Location = new Point(536, 301);
            textBoxOpeNewPasswordConfirm.Margin = new Padding(4, 5, 4, 5);
            textBoxOpeNewPasswordConfirm.MinimumSize = new Size(1, 16);
            textBoxOpeNewPasswordConfirm.Name = "textBoxOpeNewPasswordConfirm";
            textBoxOpeNewPasswordConfirm.Padding = new Padding(12, 5, 12, 5);
            textBoxOpeNewPasswordConfirm.PasswordChar = '•';
            textBoxOpeNewPasswordConfirm.Radius = 6;
            textBoxOpeNewPasswordConfirm.RectColor = Color.Navy;
            textBoxOpeNewPasswordConfirm.RectSize = 2;
            textBoxOpeNewPasswordConfirm.ShowText = false;
            textBoxOpeNewPasswordConfirm.Size = new Size(341, 50);
            textBoxOpeNewPasswordConfirm.TabIndex = 32;
            textBoxOpeNewPasswordConfirm.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxOpeNewPasswordConfirm.Watermark = "Repite la nueva contraseña";
            textBoxOpeNewPasswordConfirm.WatermarkActiveColor = Color.DarkGray;
            textBoxOpeNewPasswordConfirm.WatermarkColor = SystemColors.GrayText;
            // 
            // UCSettings
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(textBoxOpeNewPasswordConfirm);
            Controls.Add(textBoxAdminNewPasswordConfirm);
            Controls.Add(btnResetOperator);
            Controls.Add(textBoxOpeNewPassword);
            Controls.Add(uiLabel3);
            Controls.Add(btnSaveAdmin);
            Controls.Add(textBoxAdminNewPassword);
            Controls.Add(textBoxAdminOldPassword);
            Controls.Add(uiLabel2);
            Controls.Add(line);
            Controls.Add(uiLabel1);
            Controls.Add(labelTitle);
            MaximumSize = new Size(946, 707);
            MinimumSize = new Size(946, 707);
            Name = "UCSettings";
            Size = new Size(946, 707);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel labelTitle;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILine line;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox textBoxAdminOldPassword;
        private Sunny.UI.UITextBox textBoxAdminNewPassword;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Sunny.UI.UIButton btnSaveAdmin;
        private Sunny.UI.UIButton btnResetOperator;
        private Sunny.UI.UITextBox textBoxOpeNewPassword;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox textBoxAdminNewPasswordConfirm;
        private Sunny.UI.UITextBox textBoxOpeNewPasswordConfirm;
    }
}
