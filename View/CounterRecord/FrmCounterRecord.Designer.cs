namespace CasinoCounterSystem.View
{
    partial class FrmCounterRecord
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
            NavBar = new Sunny.UI.UINavBar();
            uiLabel1 = new Sunny.UI.UILabel();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiComboBox2 = new Sunny.UI.UIComboBox();
            uiComboBox3 = new Sunny.UI.UIComboBox();
            uiTextBox2 = new Sunny.UI.UITextBox();
            uiTextBox3 = new Sunny.UI.UITextBox();
            uiTextBox4 = new Sunny.UI.UITextBox();
            button_join = new Sunny.UI.UIButton();
            uiButton1 = new Sunny.UI.UIButton();
            NavBar.SuspendLayout();
            SuspendLayout();
            // 
            // NavBar
            // 
            NavBar.BackColor = Color.Navy;
            NavBar.Controls.Add(uiLabel1);
            NavBar.Dock = DockStyle.Top;
            NavBar.DropMenuFont = new Font("Microsoft Sans Serif", 12F);
            NavBar.Font = new Font("Microsoft Sans Serif", 12F);
            NavBar.Location = new Point(0, 0);
            NavBar.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            NavBar.Name = "NavBar";
            NavBar.Size = new Size(448, 63);
            NavBar.TabIndex = 0;
            NavBar.Text = "NavBar";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabel1.ForeColor = Color.White;
            uiLabel1.Location = new Point(114, 9);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(232, 34);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "Counter Record";
            uiLabel1.Click += uiLabel1_Click;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox1.Location = new Point(47, 210);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(351, 50);
            uiTextBox1.TabIndex = 1;
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "Counter Date";
            uiTextBox1.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox1.WatermarkColor = SystemColors.GrayText;
            // 
            // uiComboBox2
            // 
            uiComboBox2.DataSource = null;
            uiComboBox2.FillColor = Color.White;
            uiComboBox2.Font = new Font("Microsoft Sans Serif", 12F);
            uiComboBox2.ItemHoverColor = Color.FromArgb(155, 200, 255);
            uiComboBox2.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            uiComboBox2.Location = new Point(47, 90);
            uiComboBox2.Margin = new Padding(4, 5, 4, 5);
            uiComboBox2.MinimumSize = new Size(63, 0);
            uiComboBox2.Name = "uiComboBox2";
            uiComboBox2.Padding = new Padding(0, 0, 30, 2);
            uiComboBox2.Size = new Size(351, 50);
            uiComboBox2.SymbolSize = 24;
            uiComboBox2.TabIndex = 3;
            uiComboBox2.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox2.Watermark = "Route Number";
            uiComboBox2.WatermarkActiveColor = SystemColors.GrayText;
            uiComboBox2.WatermarkColor = SystemColors.GrayText;
            uiComboBox2.SelectedIndexChanged += uiComboBox2_SelectedIndexChanged;
            // 
            // uiComboBox3
            // 
            uiComboBox3.DataSource = null;
            uiComboBox3.FillColor = Color.White;
            uiComboBox3.Font = new Font("Microsoft Sans Serif", 12F);
            uiComboBox3.ItemHoverColor = Color.FromArgb(155, 200, 255);
            uiComboBox3.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            uiComboBox3.Location = new Point(47, 150);
            uiComboBox3.Margin = new Padding(4, 5, 4, 5);
            uiComboBox3.MinimumSize = new Size(63, 0);
            uiComboBox3.Name = "uiComboBox3";
            uiComboBox3.Padding = new Padding(0, 0, 30, 2);
            uiComboBox3.Size = new Size(351, 50);
            uiComboBox3.SymbolSize = 24;
            uiComboBox3.TabIndex = 4;
            uiComboBox3.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox3.Watermark = "Machine Number";
            uiComboBox3.WatermarkActiveColor = SystemColors.GrayText;
            uiComboBox3.WatermarkColor = SystemColors.GrayText;
            // 
            // uiTextBox2
            // 
            uiTextBox2.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox2.Location = new Point(47, 270);
            uiTextBox2.Margin = new Padding(4, 5, 4, 5);
            uiTextBox2.MinimumSize = new Size(1, 16);
            uiTextBox2.Name = "uiTextBox2";
            uiTextBox2.Padding = new Padding(5);
            uiTextBox2.ShowText = false;
            uiTextBox2.Size = new Size(351, 50);
            uiTextBox2.TabIndex = 3;
            uiTextBox2.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox2.Watermark = "IN";
            uiTextBox2.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox2.WatermarkColor = SystemColors.GrayText;
            // 
            // uiTextBox3
            // 
            uiTextBox3.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox3.Location = new Point(47, 330);
            uiTextBox3.Margin = new Padding(4, 5, 4, 5);
            uiTextBox3.MinimumSize = new Size(1, 16);
            uiTextBox3.Name = "uiTextBox3";
            uiTextBox3.Padding = new Padding(5);
            uiTextBox3.ShowText = false;
            uiTextBox3.Size = new Size(351, 50);
            uiTextBox3.TabIndex = 4;
            uiTextBox3.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox3.Watermark = "OUT";
            uiTextBox3.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox3.WatermarkColor = SystemColors.GrayText;
            // 
            // uiTextBox4
            // 
            uiTextBox4.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox4.Location = new Point(47, 390);
            uiTextBox4.Margin = new Padding(4, 5, 4, 5);
            uiTextBox4.MinimumSize = new Size(1, 16);
            uiTextBox4.Name = "uiTextBox4";
            uiTextBox4.Padding = new Padding(5);
            uiTextBox4.ShowText = false;
            uiTextBox4.Size = new Size(351, 50);
            uiTextBox4.TabIndex = 5;
            uiTextBox4.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox4.Watermark = "TOTAL";
            uiTextBox4.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox4.WatermarkColor = SystemColors.GrayText;
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
            button_join.Location = new Point(103, 473);
            button_join.MinimumSize = new Size(1, 1);
            button_join.Name = "button_join";
            button_join.RectColor = Color.FromArgb(37, 99, 235);
            button_join.RectHoverColor = Color.FromArgb(59, 130, 246);
            button_join.RectPressColor = Color.FromArgb(29, 78, 216);
            button_join.Size = new Size(108, 36);
            button_join.TabIndex = 11;
            button_join.Text = "Add";
            button_join.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiButton1
            // 
            uiButton1.BackColor = Color.White;
            uiButton1.FillColor = Color.Navy;
            uiButton1.FillColor2 = Color.Navy;
            uiButton1.FillHoverColor = Color.FromArgb(30, 58, 138);
            uiButton1.FillPressColor = Color.FromArgb(0, 0, 102);
            uiButton1.FillSelectedColor = Color.FromArgb(30, 64, 175);
            uiButton1.Font = new Font("Microsoft Sans Serif", 12F);
            uiButton1.Location = new Point(238, 473);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.RectColor = Color.FromArgb(37, 99, 235);
            uiButton1.RectHoverColor = Color.FromArgb(59, 130, 246);
            uiButton1.RectPressColor = Color.FromArgb(29, 78, 216);
            uiButton1.Size = new Size(108, 36);
            uiButton1.TabIndex = 12;
            uiButton1.Text = "Cancel";
            uiButton1.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // FrmCounterRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 548);
            Controls.Add(uiTextBox4);
            Controls.Add(uiTextBox3);
            Controls.Add(uiTextBox2);
            Controls.Add(uiComboBox3);
            Controls.Add(uiComboBox2);
            Controls.Add(uiTextBox1);
            Controls.Add(NavBar);
            Controls.Add(button_join);
            Controls.Add(uiButton1);
            Name = "FrmCounterRecord";
            Text = "FrmCounterRecord";
            NavBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UINavBar NavBar;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UIComboBox uiComboBox2;
        private Sunny.UI.UIComboBox uiComboBox3;
        private Sunny.UI.UITextBox uiTextBox2;
        private Sunny.UI.UITextBox uiTextBox3;
        private Sunny.UI.UITextBox uiTextBox4;
        private Sunny.UI.UIButton button_join;
        private Sunny.UI.UIButton uiButton1;
    }
}