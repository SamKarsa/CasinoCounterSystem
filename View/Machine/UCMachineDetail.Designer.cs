namespace CasinoCounterSystem.View.Machine
{
    partial class UCMachineDetail
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            labelTitle = new Sunny.UI.UILabel();
            lblMachineNumber = new Sunny.UI.UILabel();
            dataGridView1 = new Sunny.UI.UIDataGridView();
            panel1 = new Panel();
            lblCoinType = new Sunny.UI.UILabel();
            lblTypeMachine = new Sunny.UI.UILabel();
            uiLabel5 = new Sunny.UI.UILabel();
            uiLine4 = new Sunny.UI.UILine();
            uiLabel6 = new Sunny.UI.UILabel();
            NavBarMachineDate = new Sunny.UI.UINavBar();
            LabelTitleNavBar = new Sunny.UI.UILabel();
            uiLine3 = new Sunny.UI.UILine();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLine2 = new Sunny.UI.UILine();
            uiLine1 = new Sunny.UI.UILine();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            NavBarMachineDate.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Britannic Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Navy;
            labelTitle.Location = new Point(12, 59);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(452, 50);
            labelTitle.TabIndex = 17;
            labelTitle.Text = "Detalle de máquina";
            // 
            // lblMachineNumber
            // 
            lblMachineNumber.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMachineNumber.ForeColor = Color.FromArgb(48, 48, 48);
            lblMachineNumber.Location = new Point(157, 38);
            lblMachineNumber.Name = "lblMachineNumber";
            lblMachineNumber.Size = new Size(91, 23);
            lblMachineNumber.TabIndex = 18;
            lblMachineNumber.Text = "Machine N";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridView1.GridColor = Color.FromArgb(80, 160, 255);
            dataGridView1.Location = new Point(21, 166);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RectColor = Color.Navy;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridView1.SelectedIndex = -1;
            dataGridView1.Size = new Size(913, 529);
            dataGridView1.StripeOddColor = Color.FromArgb(235, 243, 255);
            dataGridView1.TabIndex = 21;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Lavender;
            panel1.Controls.Add(lblCoinType);
            panel1.Controls.Add(lblTypeMachine);
            panel1.Controls.Add(uiLabel5);
            panel1.Controls.Add(uiLine4);
            panel1.Controls.Add(uiLabel6);
            panel1.Controls.Add(NavBarMachineDate);
            panel1.Controls.Add(uiLine3);
            panel1.Controls.Add(lblMachineNumber);
            panel1.Controls.Add(uiLabel1);
            panel1.Controls.Add(uiLine2);
            panel1.Controls.Add(uiLine1);
            panel1.Location = new Point(661, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 129);
            panel1.TabIndex = 22;
            // 
            // lblCoinType
            // 
            lblCoinType.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoinType.ForeColor = Color.FromArgb(48, 48, 48);
            lblCoinType.Location = new Point(157, 100);
            lblCoinType.Name = "lblCoinType";
            lblCoinType.Size = new Size(91, 23);
            lblCoinType.TabIndex = 32;
            lblCoinType.Text = "Coin Type";
            // 
            // lblTypeMachine
            // 
            lblTypeMachine.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTypeMachine.ForeColor = Color.FromArgb(48, 48, 48);
            lblTypeMachine.Location = new Point(157, 69);
            lblTypeMachine.Name = "lblTypeMachine";
            lblTypeMachine.Size = new Size(91, 23);
            lblTypeMachine.TabIndex = 31;
            lblTypeMachine.Text = "Type";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabel5.ForeColor = Color.Navy;
            uiLabel5.Location = new Point(30, 100);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(91, 25);
            uiLabel5.TabIndex = 30;
            uiLabel5.Text = "T. Moneda";
            // 
            // uiLine4
            // 
            uiLine4.BackColor = Color.Transparent;
            uiLine4.Font = new Font("Microsoft Sans Serif", 12F);
            uiLine4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine4.LineColor = Color.Navy;
            uiLine4.Location = new Point(0, 122);
            uiLine4.MinimumSize = new Size(1, 1);
            uiLine4.Name = "uiLine4";
            uiLine4.Size = new Size(285, 10);
            uiLine4.TabIndex = 29;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabel6.ForeColor = Color.Navy;
            uiLabel6.Location = new Point(30, 69);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(91, 25);
            uiLabel6.TabIndex = 28;
            uiLabel6.Text = "T. Máquina";
            // 
            // NavBarMachineDate
            // 
            NavBarMachineDate.BackColor = Color.Navy;
            NavBarMachineDate.Controls.Add(LabelTitleNavBar);
            NavBarMachineDate.Dock = DockStyle.Top;
            NavBarMachineDate.DropMenuFont = new Font("Microsoft Sans Serif", 12F);
            NavBarMachineDate.Font = new Font("Microsoft Sans Serif", 12F);
            NavBarMachineDate.ForeColor = Color.White;
            NavBarMachineDate.Location = new Point(0, 0);
            NavBarMachineDate.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            NavBarMachineDate.Name = "NavBarMachineDate";
            NavBarMachineDate.RightToLeft = RightToLeft.Yes;
            NavBarMachineDate.Size = new Size(273, 35);
            NavBarMachineDate.TabIndex = 0;
            NavBarMachineDate.Text = "Machine Data";
            // 
            // LabelTitleNavBar
            // 
            LabelTitleNavBar.Font = new Font("Britannic Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelTitleNavBar.ForeColor = Color.White;
            LabelTitleNavBar.Location = new Point(48, 3);
            LabelTitleNavBar.Name = "LabelTitleNavBar";
            LabelTitleNavBar.Size = new Size(174, 35);
            LabelTitleNavBar.TabIndex = 23;
            LabelTitleNavBar.Text = "Datos Máquina";
            // 
            // uiLine3
            // 
            uiLine3.BackColor = Color.Transparent;
            uiLine3.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            uiLine3.Font = new Font("Microsoft Sans Serif", 12F);
            uiLine3.ForeColor = Color.OldLace;
            uiLine3.LineColor = Color.Navy;
            uiLine3.Location = new Point(141, 10);
            uiLine3.MinimumSize = new Size(1, 1);
            uiLine3.Name = "uiLine3";
            uiLine3.Size = new Size(10, 252);
            uiLine3.TabIndex = 26;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabel1.ForeColor = Color.Navy;
            uiLabel1.Location = new Point(38, 38);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(73, 25);
            uiLabel1.TabIndex = 23;
            uiLabel1.Text = "Máquina";
            // 
            // uiLine2
            // 
            uiLine2.BackColor = Color.Transparent;
            uiLine2.Font = new Font("Microsoft Sans Serif", 12F);
            uiLine2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine2.LineColor = Color.Navy;
            uiLine2.Location = new Point(0, 91);
            uiLine2.MinimumSize = new Size(1, 1);
            uiLine2.Name = "uiLine2";
            uiLine2.Size = new Size(285, 10);
            uiLine2.TabIndex = 24;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.LineColor = Color.Navy;
            uiLine1.Location = new Point(-46, 60);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(433, 10);
            uiLine1.TabIndex = 23;
            // 
            // UCMachineDetail
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(labelTitle);
            Controls.Add(dataGridView1);
            MaximumSize = new Size(946, 707);
            MinimumSize = new Size(946, 707);
            Name = "UCMachineDetail";
            Size = new Size(946, 707);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            NavBarMachineDate.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel labelTitle;
        private Sunny.UI.UILabel lblMachineNumber;
        private Sunny.UI.UIDataGridView dataGridView1;
        private Panel panel1;
        private Sunny.UI.UINavBar NavBarMachineDate;
        private Sunny.UI.UILabel LabelTitleNavBar;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UILabel lblCoinType;
        private Sunny.UI.UILabel lblTypeMachine;
    }
}
