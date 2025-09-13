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
            ComboBoxRoute = new Sunny.UI.UIComboBox();
            ComboBoxMachine = new Sunny.UI.UIComboBox();
            TextBoxIN = new Sunny.UI.UITextBox();
            TextBoxOUT = new Sunny.UI.UITextBox();
            TextBoxTotal = new Sunny.UI.UITextBox();
            button_join = new Sunny.UI.UIButton();
            ButtonCancel = new Sunny.UI.UIButton();
            DatetimePicker = new Sunny.UI.UIDatetimePicker();
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
            NavBar.Size = new Size(448, 68);
            NavBar.TabIndex = 0;
            NavBar.Text = "NavBar";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabel1.ForeColor = Color.White;
            uiLabel1.ImageAlign = ContentAlignment.BottomCenter;
            uiLabel1.Location = new Point(89, 9);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(278, 34);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "💼 Counter Record";
            // 
            // ComboBoxRoute
            // 
            ComboBoxRoute.DataSource = null;
            ComboBoxRoute.FillColor = Color.White;
            ComboBoxRoute.Font = new Font("Microsoft Sans Serif", 12F);
            ComboBoxRoute.ItemHoverColor = Color.FromArgb(155, 200, 255);
            ComboBoxRoute.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            ComboBoxRoute.Location = new Point(47, 90);
            ComboBoxRoute.Margin = new Padding(4, 5, 4, 5);
            ComboBoxRoute.MinimumSize = new Size(63, 0);
            ComboBoxRoute.Name = "ComboBoxRoute";
            ComboBoxRoute.Padding = new Padding(5, 0, 30, 2);
            ComboBoxRoute.RectColor = Color.Navy;
            ComboBoxRoute.Size = new Size(351, 50);
            ComboBoxRoute.SymbolSize = 24;
            ComboBoxRoute.TabIndex = 3;
            ComboBoxRoute.TextAlignment = ContentAlignment.MiddleLeft;
            ComboBoxRoute.Watermark = "Route Number";
            ComboBoxRoute.WatermarkActiveColor = SystemColors.GrayText;
            ComboBoxRoute.WatermarkColor = SystemColors.GrayText;
            // 
            // ComboBoxMachine
            // 
            ComboBoxMachine.DataSource = null;
            ComboBoxMachine.FillColor = Color.White;
            ComboBoxMachine.Font = new Font("Microsoft Sans Serif", 12F);
            ComboBoxMachine.ItemHoverColor = Color.FromArgb(155, 200, 255);
            ComboBoxMachine.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            ComboBoxMachine.Location = new Point(47, 150);
            ComboBoxMachine.Margin = new Padding(4, 5, 4, 5);
            ComboBoxMachine.MinimumSize = new Size(63, 0);
            ComboBoxMachine.Name = "ComboBoxMachine";
            ComboBoxMachine.Padding = new Padding(5, 0, 30, 2);
            ComboBoxMachine.RectColor = Color.Navy;
            ComboBoxMachine.Size = new Size(351, 50);
            ComboBoxMachine.SymbolSize = 24;
            ComboBoxMachine.TabIndex = 4;
            ComboBoxMachine.TextAlignment = ContentAlignment.MiddleLeft;
            ComboBoxMachine.Watermark = "Machine Number";
            ComboBoxMachine.WatermarkActiveColor = SystemColors.GrayText;
            ComboBoxMachine.WatermarkColor = SystemColors.GrayText;
            // 
            // TextBoxIN
            // 
            TextBoxIN.Font = new Font("Microsoft Sans Serif", 12F);
            TextBoxIN.Location = new Point(47, 270);
            TextBoxIN.Margin = new Padding(4, 5, 4, 5);
            TextBoxIN.MinimumSize = new Size(1, 16);
            TextBoxIN.Name = "TextBoxIN";
            TextBoxIN.Padding = new Padding(5, 0, 30, 2);
            TextBoxIN.RectColor = Color.Navy;
            TextBoxIN.ShowText = false;
            TextBoxIN.Size = new Size(351, 50);
            TextBoxIN.TabIndex = 3;
            TextBoxIN.TextAlignment = ContentAlignment.MiddleLeft;
            TextBoxIN.Watermark = "IN";
            TextBoxIN.WatermarkActiveColor = SystemColors.GrayText;
            TextBoxIN.WatermarkColor = SystemColors.GrayText;
            // 
            // TextBoxOUT
            // 
            TextBoxOUT.Font = new Font("Microsoft Sans Serif", 12F);
            TextBoxOUT.Location = new Point(47, 330);
            TextBoxOUT.Margin = new Padding(4, 5, 4, 5);
            TextBoxOUT.MinimumSize = new Size(1, 16);
            TextBoxOUT.Name = "TextBoxOUT";
            TextBoxOUT.Padding = new Padding(5, 0, 30, 2);
            TextBoxOUT.RectColor = Color.Navy;
            TextBoxOUT.ShowText = false;
            TextBoxOUT.Size = new Size(351, 50);
            TextBoxOUT.TabIndex = 4;
            TextBoxOUT.TextAlignment = ContentAlignment.MiddleLeft;
            TextBoxOUT.Watermark = "OUT";
            TextBoxOUT.WatermarkActiveColor = SystemColors.GrayText;
            TextBoxOUT.WatermarkColor = SystemColors.GrayText;
            // 
            // TextBoxTotal
            // 
            TextBoxTotal.Font = new Font("Microsoft Sans Serif", 12F);
            TextBoxTotal.Location = new Point(47, 390);
            TextBoxTotal.Margin = new Padding(4, 5, 4, 5);
            TextBoxTotal.MinimumSize = new Size(1, 16);
            TextBoxTotal.Name = "TextBoxTotal";
            TextBoxTotal.Padding = new Padding(5, 0, 30, 2);
            TextBoxTotal.RectColor = Color.Navy;
            TextBoxTotal.ShowText = false;
            TextBoxTotal.Size = new Size(351, 50);
            TextBoxTotal.TabIndex = 5;
            TextBoxTotal.TextAlignment = ContentAlignment.MiddleLeft;
            TextBoxTotal.Watermark = "Total";
            TextBoxTotal.WatermarkActiveColor = SystemColors.GrayText;
            TextBoxTotal.WatermarkColor = SystemColors.GrayText;
            // 
            // button_join
            // 
            button_join.BackColor = Color.White;
            button_join.FillColor = Color.Navy;
            button_join.FillColor2 = Color.Navy;
            button_join.FillHoverColor = Color.FromArgb(30, 58, 138);
            button_join.FillPressColor = Color.FromArgb(0, 0, 102);
            button_join.FillSelectedColor = Color.FromArgb(30, 64, 175);
            button_join.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_join.Location = new Point(89, 465);
            button_join.MinimumSize = new Size(1, 1);
            button_join.Name = "button_join";
            button_join.RectColor = Color.FromArgb(37, 99, 235);
            button_join.RectHoverColor = Color.FromArgb(59, 130, 246);
            button_join.RectPressColor = Color.FromArgb(29, 78, 216);
            button_join.Size = new Size(114, 44);
            button_join.TabIndex = 11;
            button_join.Text = "➕Add";
            button_join.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // ButtonCancel
            // 
            ButtonCancel.BackColor = Color.White;
            ButtonCancel.FillColor = Color.White;
            ButtonCancel.FillColor2 = Color.Navy;
            ButtonCancel.FillHoverColor = Color.FromArgb(30, 58, 138);
            ButtonCancel.FillPressColor = Color.FromArgb(0, 0, 102);
            ButtonCancel.FillSelectedColor = Color.FromArgb(30, 64, 175);
            ButtonCancel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonCancel.ForeColor = Color.Navy;
            ButtonCancel.Location = new Point(238, 465);
            ButtonCancel.MinimumSize = new Size(1, 1);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.RectColor = Color.RoyalBlue;
            ButtonCancel.RectHoverColor = Color.FromArgb(59, 130, 246);
            ButtonCancel.RectPressColor = Color.FromArgb(29, 78, 216);
            ButtonCancel.RectSize = 2;
            ButtonCancel.Size = new Size(114, 44);
            ButtonCancel.TabIndex = 12;
            ButtonCancel.Text = "🗑️Cancel";
            ButtonCancel.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // DatetimePicker
            // 
            DatetimePicker.DateFormat = "dd-MM-yyyy";
            DatetimePicker.FillColor = Color.White;
            DatetimePicker.Font = new Font("Microsoft Sans Serif", 12F);
            DatetimePicker.Location = new Point(47, 210);
            DatetimePicker.Margin = new Padding(4, 5, 4, 5);
            DatetimePicker.MaxLength = 10;
            DatetimePicker.MinimumSize = new Size(63, 0);
            DatetimePicker.Name = "DatetimePicker";
            DatetimePicker.Padding = new Padding(0, 0, 30, 2);
            DatetimePicker.RectColor = Color.Navy;
            DatetimePicker.Size = new Size(351, 50);
            DatetimePicker.SymbolDropDown = 61555;
            DatetimePicker.SymbolNormal = 61555;
            DatetimePicker.SymbolSize = 24;
            DatetimePicker.TabIndex = 13;
            DatetimePicker.Text = "12-09-2025";
            DatetimePicker.TextAlignment = ContentAlignment.MiddleLeft;
            DatetimePicker.Value = new DateTime(2025, 9, 12, 22, 48, 24, 986);
            DatetimePicker.Watermark = "Counter Date";
            DatetimePicker.WatermarkActiveColor = SystemColors.GrayText;
            DatetimePicker.WatermarkColor = SystemColors.GrayText;
            // 
            // FrmCounterRecord
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(448, 548);
            Controls.Add(TextBoxTotal);
            Controls.Add(TextBoxOUT);
            Controls.Add(TextBoxIN);
            Controls.Add(ComboBoxMachine);
            Controls.Add(ComboBoxRoute);
            Controls.Add(NavBar);
            Controls.Add(button_join);
            Controls.Add(ButtonCancel);
            Controls.Add(DatetimePicker);
            MaximumSize = new Size(464, 587);
            MinimumSize = new Size(464, 587);
            Name = "FrmCounterRecord";
            Text = "FrmCounterRecord";
            NavBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UINavBar NavBar;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox ComboBoxRoute;
        private Sunny.UI.UIComboBox ComboBoxMachine;
        private Sunny.UI.UITextBox TextBoxIN;
        private Sunny.UI.UITextBox TextBoxOUT;
        private Sunny.UI.UITextBox TextBoxTotal;
        private Sunny.UI.UIButton button_join;
        private Sunny.UI.UIButton ButtonCancel;
        private Sunny.UI.UIDatetimePicker DatetimePicker;
    }
}