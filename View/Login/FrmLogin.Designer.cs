namespace CasinoCounterSystem.View
{
    partial class FrmLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_login = new Label();
            link_password = new LinkLabel();
            button_join = new Sunny.UI.UIButton();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiTextBox2 = new Sunny.UI.UITextBox();
            panel_login = new Panel();
            textbox_password = new Sunny.UI.UITextBox();
            textbox_user = new Sunny.UI.UITextBox();
            panel_login.SuspendLayout();
            SuspendLayout();
            // 
            // label_login
            // 
            label_login.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_login.AutoSize = true;
            label_login.BackColor = Color.Transparent;
            label_login.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_login.ForeColor = Color.Navy;
            label_login.Location = new Point(144, 34);
            label_login.Name = "label_login";
            label_login.Size = new Size(103, 40);
            label_login.TabIndex = 8;
            label_login.Text = "Log In";
            label_login.Click += label3_Click;
            // 
            // link_password
            // 
            link_password.ActiveLinkColor = Color.DodgerBlue;
            link_password.AutoSize = true;
            link_password.BackColor = Color.Transparent;
            link_password.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            link_password.LinkColor = Color.Navy;
            link_password.Location = new Point(228, 236);
            link_password.Name = "link_password";
            link_password.Size = new Size(125, 15);
            link_password.TabIndex = 3;
            link_password.TabStop = true;
            link_password.Text = "Forgot the password?";
            // 
            // button_join
            // 
            button_join.BackColor = Color.White;
            button_join.FillColor = Color.Navy;
            button_join.FillColor2 = Color.Navy;
            button_join.FillHoverColor = Color.FromArgb(30, 58, 138);
            button_join.FillPressColor = Color.FromArgb(0, 0, 102);
            button_join.FillSelectedColor = Color.FromArgb(30, 64, 175);
            button_join.Font = new Font("Microsoft Sans Serif", 12F);
            button_join.Location = new Point(25, 236);
            button_join.MinimumSize = new Size(1, 1);
            button_join.Name = "button_join";
            button_join.RectColor = Color.FromArgb(37, 99, 235);
            button_join.RectHoverColor = Color.FromArgb(59, 130, 246);
            button_join.RectPressColor = Color.FromArgb(29, 78, 216);
            button_join.Size = new Size(123, 36);
            button_join.TabIndex = 10;
            button_join.Text = "Join";
            button_join.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiTextBox1
            // 
            uiTextBox1.BackColor = Color.White;
            uiTextBox1.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox1.Location = new Point(29, 98);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(328, 47);
            uiTextBox1.TabIndex = 9;
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "👤 Username";
            uiTextBox1.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox1.WatermarkColor = SystemColors.GrayText;
            // 
            // uiTextBox2
            // 
            uiTextBox2.BackColor = Color.White;
            uiTextBox2.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox2.Location = new Point(29, 155);
            uiTextBox2.Margin = new Padding(4, 5, 4, 5);
            uiTextBox2.MinimumSize = new Size(1, 16);
            uiTextBox2.Name = "uiTextBox2";
            uiTextBox2.Padding = new Padding(5);
            uiTextBox2.ShowText = false;
            uiTextBox2.Size = new Size(328, 47);
            uiTextBox2.TabIndex = 9;
            uiTextBox2.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox2.Watermark = "🔒 Password";
            uiTextBox2.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox2.WatermarkColor = SystemColors.GrayText;
            // 
            // panel_login
            // 
            panel_login.BackColor = Color.White;
            panel_login.Controls.Add(textbox_password);
            panel_login.Controls.Add(textbox_user);
            panel_login.Controls.Add(label_login);
            panel_login.Controls.Add(button_join);
            panel_login.Controls.Add(link_password);
            panel_login.Location = new Point(32, 30);
            panel_login.Name = "panel_login";
            panel_login.Size = new Size(380, 307);
            panel_login.TabIndex = 1;
            // 
            // textbox_password
            // 
            textbox_password.Font = new Font("Microsoft Sans Serif", 12F);
            textbox_password.Location = new Point(25, 168);
            textbox_password.Margin = new Padding(4, 5, 4, 5);
            textbox_password.MinimumSize = new Size(1, 16);
            textbox_password.Name = "textbox_password";
            textbox_password.Padding = new Padding(5);
            textbox_password.RectColor = Color.Navy;
            textbox_password.ShowText = false;
            textbox_password.Size = new Size(328, 47);
            textbox_password.TabIndex = 12;
            textbox_password.TextAlignment = ContentAlignment.MiddleLeft;
            textbox_password.Watermark = "🔒 Password";
            textbox_password.WatermarkActiveColor = SystemColors.GrayText;
            textbox_password.WatermarkColor = SystemColors.GrayText;
            textbox_password.TextChanged += textbox_password_TextChanged;
            // 
            // textbox_user
            // 
            textbox_user.Font = new Font("Microsoft Sans Serif", 12F);
            textbox_user.Location = new Point(25, 101);
            textbox_user.Margin = new Padding(4, 5, 4, 5);
            textbox_user.MinimumSize = new Size(1, 16);
            textbox_user.Name = "textbox_user";
            textbox_user.Padding = new Padding(5);
            textbox_user.RectColor = Color.Navy;
            textbox_user.ShowText = false;
            textbox_user.Size = new Size(328, 47);
            textbox_user.TabIndex = 11;
            textbox_user.TextAlignment = ContentAlignment.MiddleLeft;
            textbox_user.Watermark = "👤 Username";
            textbox_user.WatermarkActiveColor = SystemColors.GrayText;
            textbox_user.WatermarkColor = SystemColors.GrayText;
            textbox_user.TextChanged += uiTextBox3_TextChanged;
            // 
            // FrmLogin
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Navy;
            ClientSize = new Size(443, 365);
            Controls.Add(panel_login);
            MaximumSize = new Size(459, 404);
            MinimumSize = new Size(459, 404);
            Name = "FrmLogin";
            Text = "Login1";
            panel_login.ResumeLayout(false);
            panel_login.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label_login;
        private LinkLabel link_password;
        private Sunny.UI.UIButton button_join;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UITextBox uiTextBox2;
        private Panel panel_login;
        private Sunny.UI.UITextBox textbox_password;
        private Sunny.UI.UITextBox textbox_user;
    }
}