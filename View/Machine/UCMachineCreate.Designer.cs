namespace CasinoCounterSystem.View.Machine
{
    partial class UCMachineCreate
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
            imgLogo = new PictureBox();
            labelTitle = new Sunny.UI.UILabel();
            textBoxNumMachine = new Sunny.UI.UITextBox();
            comboBoxRoute = new Sunny.UI.UIComboBox();
            comboBoxMachineType = new Sunny.UI.UIComboBox();
            comboBoxCoinType = new Sunny.UI.UIComboBox();
            uiLabel1 = new Sunny.UI.UILabel();
            textBoxNameClient = new Sunny.UI.UITextBox();
            textBoxPhone = new Sunny.UI.UITextBox();
            textBoxAddress = new Sunny.UI.UITextBox();
            btnCancelRoute = new Sunny.UI.UIButton();
            btnSaveRoute = new Sunny.UI.UIButton();
            TextBoxIn = new Sunny.UI.UITextBox();
            TextBoxOut = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            SuspendLayout();
            // 
            // imgLogo
            // 
            imgLogo.BackColor = Color.Transparent;
            imgLogo.Image = Properties.Resources.logoCltElectronic;
            imgLogo.Location = new Point(764, 620);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(89, 86);
            imgLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            imgLogo.TabIndex = 15;
            imgLogo.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Britannic Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Navy;
            labelTitle.Location = new Point(277, 61);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(354, 50);
            labelTitle.TabIndex = 16;
            labelTitle.Text = "Create Machine";
            // 
            // textBoxNumMachine
            // 
            textBoxNumMachine.ButtonRectColor = Color.Navy;
            textBoxNumMachine.ButtonRectHoverColor = Color.FromArgb(30, 58, 138);
            textBoxNumMachine.ButtonRectPressColor = Color.FromArgb(37, 99, 235);
            textBoxNumMachine.ButtonStyleInherited = false;
            textBoxNumMachine.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxNumMachine.Location = new Point(433, 196);
            textBoxNumMachine.Margin = new Padding(4, 5, 4, 5);
            textBoxNumMachine.MinimumSize = new Size(1, 16);
            textBoxNumMachine.Name = "textBoxNumMachine";
            textBoxNumMachine.Padding = new Padding(12, 5, 12, 5);
            textBoxNumMachine.Radius = 6;
            textBoxNumMachine.RectColor = Color.Navy;
            textBoxNumMachine.RectSize = 2;
            textBoxNumMachine.ShowText = false;
            textBoxNumMachine.Size = new Size(346, 50);
            textBoxNumMachine.TabIndex = 18;
            textBoxNumMachine.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxNumMachine.Watermark = "Enter Number Machine";
            textBoxNumMachine.WatermarkActiveColor = Color.DarkGray;
            textBoxNumMachine.WatermarkColor = SystemColors.GrayText;
            // 
            // comboBoxRoute
            // 
            comboBoxRoute.DataSource = null;
            comboBoxRoute.FillColor = Color.White;
            comboBoxRoute.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxRoute.ItemHoverColor = Color.FromArgb(30, 58, 138);
            comboBoxRoute.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboBoxRoute.Location = new Point(79, 136);
            comboBoxRoute.Margin = new Padding(4, 5, 4, 5);
            comboBoxRoute.MinimumSize = new Size(63, 0);
            comboBoxRoute.Name = "comboBoxRoute";
            comboBoxRoute.Padding = new Padding(0, 0, 30, 2);
            comboBoxRoute.RectColor = Color.Navy;
            comboBoxRoute.Size = new Size(346, 50);
            comboBoxRoute.SymbolSize = 24;
            comboBoxRoute.TabIndex = 23;
            comboBoxRoute.TextAlignment = ContentAlignment.MiddleLeft;
            comboBoxRoute.Watermark = "Select Route";
            comboBoxRoute.WatermarkActiveColor = Color.DarkGray;
            // 
            // comboBoxMachineType
            // 
            comboBoxMachineType.DataSource = null;
            comboBoxMachineType.FillColor = Color.White;
            comboBoxMachineType.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxMachineType.ItemHoverColor = Color.FromArgb(30, 58, 138);
            comboBoxMachineType.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboBoxMachineType.Location = new Point(79, 196);
            comboBoxMachineType.Margin = new Padding(4, 5, 4, 5);
            comboBoxMachineType.MinimumSize = new Size(63, 0);
            comboBoxMachineType.Name = "comboBoxMachineType";
            comboBoxMachineType.Padding = new Padding(0, 0, 30, 2);
            comboBoxMachineType.RectColor = Color.Navy;
            comboBoxMachineType.Size = new Size(346, 50);
            comboBoxMachineType.SymbolSize = 24;
            comboBoxMachineType.TabIndex = 24;
            comboBoxMachineType.TextAlignment = ContentAlignment.MiddleLeft;
            comboBoxMachineType.Watermark = "Select Machine Type";
            comboBoxMachineType.WatermarkActiveColor = Color.DarkGray;
            // 
            // comboBoxCoinType
            // 
            comboBoxCoinType.DataSource = null;
            comboBoxCoinType.FillColor = Color.White;
            comboBoxCoinType.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxCoinType.ItemHoverColor = Color.FromArgb(30, 58, 138);
            comboBoxCoinType.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboBoxCoinType.Location = new Point(433, 136);
            comboBoxCoinType.Margin = new Padding(4, 5, 4, 5);
            comboBoxCoinType.MinimumSize = new Size(63, 0);
            comboBoxCoinType.Name = "comboBoxCoinType";
            comboBoxCoinType.Padding = new Padding(0, 0, 30, 2);
            comboBoxCoinType.RectColor = Color.Navy;
            comboBoxCoinType.Size = new Size(346, 50);
            comboBoxCoinType.SymbolSize = 24;
            comboBoxCoinType.TabIndex = 25;
            comboBoxCoinType.TextAlignment = ContentAlignment.MiddleLeft;
            comboBoxCoinType.Watermark = "Select Coin Type";
            comboBoxCoinType.WatermarkActiveColor = Color.DarkGray;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("Britannic Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uiLabel1.ForeColor = Color.Navy;
            uiLabel1.Location = new Point(302, 364);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(297, 50);
            uiLabel1.TabIndex = 26;
            uiLabel1.Text = "Info Machine";
            // 
            // textBoxNameClient
            // 
            textBoxNameClient.ButtonRectColor = Color.Navy;
            textBoxNameClient.ButtonRectHoverColor = Color.FromArgb(30, 58, 138);
            textBoxNameClient.ButtonRectPressColor = Color.FromArgb(37, 99, 235);
            textBoxNameClient.ButtonStyleInherited = false;
            textBoxNameClient.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxNameClient.Location = new Point(72, 442);
            textBoxNameClient.Margin = new Padding(4, 5, 4, 5);
            textBoxNameClient.MinimumSize = new Size(1, 16);
            textBoxNameClient.Name = "textBoxNameClient";
            textBoxNameClient.Padding = new Padding(12, 5, 12, 5);
            textBoxNameClient.Radius = 6;
            textBoxNameClient.RectColor = Color.Navy;
            textBoxNameClient.RectSize = 2;
            textBoxNameClient.ShowText = false;
            textBoxNameClient.Size = new Size(346, 50);
            textBoxNameClient.TabIndex = 19;
            textBoxNameClient.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxNameClient.Watermark = "Enter Name Client";
            textBoxNameClient.WatermarkActiveColor = Color.DarkGray;
            // 
            // textBoxPhone
            // 
            textBoxPhone.ButtonRectColor = Color.Navy;
            textBoxPhone.ButtonRectHoverColor = Color.FromArgb(30, 58, 138);
            textBoxPhone.ButtonRectPressColor = Color.FromArgb(37, 99, 235);
            textBoxPhone.ButtonStyleInherited = false;
            textBoxPhone.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxPhone.Location = new Point(426, 442);
            textBoxPhone.Margin = new Padding(4, 5, 4, 5);
            textBoxPhone.MinimumSize = new Size(1, 16);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Padding = new Padding(12, 5, 12, 5);
            textBoxPhone.Radius = 6;
            textBoxPhone.RectColor = Color.Navy;
            textBoxPhone.RectSize = 2;
            textBoxPhone.ShowText = false;
            textBoxPhone.Size = new Size(346, 50);
            textBoxPhone.TabIndex = 20;
            textBoxPhone.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxPhone.Watermark = "Enter Phone Client";
            textBoxPhone.WatermarkActiveColor = Color.DarkGray;
            // 
            // textBoxAddress
            // 
            textBoxAddress.ButtonRectColor = Color.Navy;
            textBoxAddress.ButtonRectHoverColor = Color.FromArgb(30, 58, 138);
            textBoxAddress.ButtonRectPressColor = Color.FromArgb(37, 99, 235);
            textBoxAddress.ButtonStyleInherited = false;
            textBoxAddress.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxAddress.Location = new Point(278, 502);
            textBoxAddress.Margin = new Padding(4, 5, 4, 5);
            textBoxAddress.MinimumSize = new Size(1, 16);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Padding = new Padding(12, 5, 12, 5);
            textBoxAddress.Radius = 6;
            textBoxAddress.RectColor = Color.Navy;
            textBoxAddress.RectSize = 2;
            textBoxAddress.ShowText = false;
            textBoxAddress.Size = new Size(346, 50);
            textBoxAddress.TabIndex = 21;
            textBoxAddress.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxAddress.Watermark = "Enter Address";
            textBoxAddress.WatermarkActiveColor = Color.DarkGray;
            // 
            // btnCancelRoute
            // 
            btnCancelRoute.BackColor = Color.White;
            btnCancelRoute.FillColor = Color.FromArgb(229, 231, 235);
            btnCancelRoute.FillColor2 = Color.FromArgb(229, 231, 235);
            btnCancelRoute.FillDisableColor = Color.FromArgb(243, 244, 246);
            btnCancelRoute.FillHoverColor = Color.FromArgb(209, 213, 219);
            btnCancelRoute.FillPressColor = Color.FromArgb(156, 163, 175);
            btnCancelRoute.FillSelectedColor = Color.FromArgb(209, 213, 219);
            btnCancelRoute.Font = new Font("Microsoft Sans Serif", 12F);
            btnCancelRoute.ForeColor = Color.Navy;
            btnCancelRoute.ForeDisableColor = Color.FromArgb(156, 163, 175);
            btnCancelRoute.ForeHoverColor = Color.Navy;
            btnCancelRoute.ForePressColor = Color.Navy;
            btnCancelRoute.ForeSelectedColor = Color.Navy;
            btnCancelRoute.Location = new Point(476, 605);
            btnCancelRoute.MinimumSize = new Size(1, 1);
            btnCancelRoute.Name = "btnCancelRoute";
            btnCancelRoute.RectColor = Color.FromArgb(209, 213, 219);
            btnCancelRoute.RectDisableColor = Color.FromArgb(229, 231, 235);
            btnCancelRoute.RectHoverColor = Color.FromArgb(156, 163, 175);
            btnCancelRoute.RectPressColor = Color.FromArgb(107, 114, 128);
            btnCancelRoute.RectSelectedColor = Color.FromArgb(156, 163, 175);
            btnCancelRoute.Size = new Size(155, 50);
            btnCancelRoute.TabIndex = 28;
            btnCancelRoute.Text = "🗑️ Cancel";
            btnCancelRoute.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnCancelRoute.Click += BtnCancel_Click;
            // 
            // btnSaveRoute
            // 
            btnSaveRoute.BackColor = Color.White;
            btnSaveRoute.FillColor = Color.Navy;
            btnSaveRoute.FillColor2 = Color.Navy;
            btnSaveRoute.FillDisableColor = Color.FromArgb(229, 231, 235);
            btnSaveRoute.FillHoverColor = Color.FromArgb(30, 58, 138);
            btnSaveRoute.FillPressColor = Color.FromArgb(0, 0, 102);
            btnSaveRoute.FillSelectedColor = Color.FromArgb(30, 64, 175);
            btnSaveRoute.Font = new Font("Microsoft Sans Serif", 12F);
            btnSaveRoute.ForeDisableColor = Color.FromArgb(156, 163, 175);
            btnSaveRoute.Location = new Point(263, 605);
            btnSaveRoute.MinimumSize = new Size(1, 1);
            btnSaveRoute.Name = "btnSaveRoute";
            btnSaveRoute.RectColor = Color.Navy;
            btnSaveRoute.RectDisableColor = Color.FromArgb(209, 213, 219);
            btnSaveRoute.RectHoverColor = Color.FromArgb(30, 58, 138);
            btnSaveRoute.RectPressColor = Color.FromArgb(0, 0, 102);
            btnSaveRoute.RectSelectedColor = Color.FromArgb(30, 64, 175);
            btnSaveRoute.Size = new Size(155, 50);
            btnSaveRoute.TabIndex = 27;
            btnSaveRoute.Text = "➕ Save";
            btnSaveRoute.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // TextBoxIn
            // 
            TextBoxIn.ButtonRectColor = Color.Navy;
            TextBoxIn.ButtonRectHoverColor = Color.FromArgb(30, 58, 138);
            TextBoxIn.ButtonRectPressColor = Color.FromArgb(37, 99, 235);
            TextBoxIn.ButtonStyleInherited = false;
            TextBoxIn.Font = new Font("Microsoft Sans Serif", 12F);
            TextBoxIn.Location = new Point(79, 256);
            TextBoxIn.Margin = new Padding(4, 5, 4, 5);
            TextBoxIn.MinimumSize = new Size(1, 16);
            TextBoxIn.Name = "TextBoxIn";
            TextBoxIn.Padding = new Padding(12, 5, 12, 5);
            TextBoxIn.Radius = 6;
            TextBoxIn.RectColor = Color.Navy;
            TextBoxIn.RectSize = 2;
            TextBoxIn.ShowText = false;
            TextBoxIn.Size = new Size(346, 50);
            TextBoxIn.TabIndex = 19;
            TextBoxIn.TextAlignment = ContentAlignment.MiddleLeft;
            TextBoxIn.Watermark = "Installation IN";
            TextBoxIn.WatermarkActiveColor = Color.DarkGray;
            // 
            // TextBoxOut
            // 
            TextBoxOut.ButtonRectColor = Color.Navy;
            TextBoxOut.ButtonRectHoverColor = Color.FromArgb(30, 58, 138);
            TextBoxOut.ButtonRectPressColor = Color.FromArgb(37, 99, 235);
            TextBoxOut.ButtonStyleInherited = false;
            TextBoxOut.Font = new Font("Microsoft Sans Serif", 12F);
            TextBoxOut.Location = new Point(433, 256);
            TextBoxOut.Margin = new Padding(4, 5, 4, 5);
            TextBoxOut.MinimumSize = new Size(1, 16);
            TextBoxOut.Name = "TextBoxOut";
            TextBoxOut.Padding = new Padding(12, 5, 12, 5);
            TextBoxOut.Radius = 6;
            TextBoxOut.RectColor = Color.Navy;
            TextBoxOut.RectSize = 2;
            TextBoxOut.ShowText = false;
            TextBoxOut.Size = new Size(346, 50);
            TextBoxOut.TabIndex = 20;
            TextBoxOut.TextAlignment = ContentAlignment.MiddleLeft;
            TextBoxOut.Watermark = "Installation OUT";
            TextBoxOut.WatermarkActiveColor = Color.DarkGray;
            TextBoxOut.WatermarkColor = SystemColors.GrayText;
            // 
            // UCMachineCreate
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(TextBoxOut);
            Controls.Add(TextBoxIn);
            Controls.Add(btnCancelRoute);
            Controls.Add(btnSaveRoute);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxNameClient);
            Controls.Add(uiLabel1);
            Controls.Add(comboBoxCoinType);
            Controls.Add(comboBoxMachineType);
            Controls.Add(comboBoxRoute);
            Controls.Add(textBoxNumMachine);
            Controls.Add(labelTitle);
            Controls.Add(imgLogo);
            MaximumSize = new Size(863, 712);
            MinimumSize = new Size(863, 712);
            Name = "UCMachineCreate";
            Size = new Size(863, 712);
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox imgLogo;
        private Sunny.UI.UILabel labelTitle;
        private Sunny.UI.UITextBox textBoxNumMachine;
        private Sunny.UI.UIComboBox comboBoxRoute;
        private Sunny.UI.UIComboBox comboBoxMachineType;
        private Sunny.UI.UIComboBox comboBoxCoinType;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox textBoxNameClient;
        private Sunny.UI.UITextBox textBoxPhone;
        private Sunny.UI.UITextBox textBoxAddress;
        private Sunny.UI.UIButton btnCancelRoute;
        private Sunny.UI.UIButton btnSaveRoute;
        private Sunny.UI.UITextBox TextBoxIn;
        private Sunny.UI.UITextBox TextBoxOut;
    }
}
