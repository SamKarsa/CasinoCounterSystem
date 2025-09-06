namespace CasinoCounterSystem.View.Home
{
    partial class UCHome
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
            welcomeLabel = new Sunny.UI.UILabel();
            btnAddMachine = new Sunny.UI.UIButton();
            btnAddRoute = new Sunny.UI.UIButton();
            imgLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = AnchorStyles.None;
            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.Font = new Font("Microsoft Sans Serif", 16F);
            welcomeLabel.ForeColor = Color.Gray;
            welcomeLabel.Location = new Point(172, 254);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(500, 150);
            welcomeLabel.TabIndex = 10;
            welcomeLabel.Text = "Select an option from the sidebar\nto get started with your\nCasino Counter System";
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddMachine
            // 
            btnAddMachine.BackColor = Color.White;
            btnAddMachine.FillColor = Color.Navy;
            btnAddMachine.FillColor2 = Color.Navy;
            btnAddMachine.FillDisableColor = Color.FromArgb(229, 231, 235);
            btnAddMachine.FillHoverColor = Color.FromArgb(30, 58, 138);
            btnAddMachine.FillPressColor = Color.FromArgb(0, 0, 102);
            btnAddMachine.FillSelectedColor = Color.FromArgb(30, 64, 175);
            btnAddMachine.Font = new Font("Microsoft Sans Serif", 12F);
            btnAddMachine.ForeDisableColor = Color.FromArgb(156, 163, 175);
            btnAddMachine.Location = new Point(543, 12);
            btnAddMachine.MinimumSize = new Size(1, 1);
            btnAddMachine.Name = "btnAddMachine";
            btnAddMachine.RectColor = Color.Navy;
            btnAddMachine.RectDisableColor = Color.FromArgb(209, 213, 219);
            btnAddMachine.RectHoverColor = Color.FromArgb(30, 58, 138);
            btnAddMachine.RectPressColor = Color.FromArgb(0, 0, 102);
            btnAddMachine.RectSelectedColor = Color.FromArgb(30, 64, 175);
            btnAddMachine.Size = new Size(143, 35);
            btnAddMachine.TabIndex = 11;
            btnAddMachine.Text = "➕ Add Machine";
            btnAddMachine.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnAddRoute
            // 
            btnAddRoute.BackColor = Color.White;
            btnAddRoute.FillColor = Color.Navy;
            btnAddRoute.FillColor2 = Color.Navy;
            btnAddRoute.FillDisableColor = Color.FromArgb(229, 231, 235);
            btnAddRoute.FillHoverColor = Color.FromArgb(30, 58, 138);
            btnAddRoute.FillPressColor = Color.FromArgb(0, 0, 102);
            btnAddRoute.FillSelectedColor = Color.FromArgb(30, 64, 175);
            btnAddRoute.Font = new Font("Microsoft Sans Serif", 12F);
            btnAddRoute.ForeDisableColor = Color.FromArgb(156, 163, 175);
            btnAddRoute.Location = new Point(692, 12);
            btnAddRoute.MinimumSize = new Size(1, 1);
            btnAddRoute.Name = "btnAddRoute";
            btnAddRoute.RectColor = Color.Navy;
            btnAddRoute.RectDisableColor = Color.FromArgb(209, 213, 219);
            btnAddRoute.RectHoverColor = Color.FromArgb(30, 58, 138);
            btnAddRoute.RectPressColor = Color.FromArgb(0, 0, 102);
            btnAddRoute.RectSelectedColor = Color.FromArgb(30, 64, 175);
            btnAddRoute.Size = new Size(143, 35);
            btnAddRoute.TabIndex = 12;
            btnAddRoute.Text = "🛣️ Add Route";
            btnAddRoute.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // imgLogo
            // 
            imgLogo.BackColor = Color.Transparent;
            imgLogo.Image = Properties.Resources.logoCltElectronic;
            imgLogo.Location = new Point(764, 620);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(89, 86);
            imgLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            imgLogo.TabIndex = 13;
            imgLogo.TabStop = false;
            // 
            // UCHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(imgLogo);
            Controls.Add(btnAddRoute);
            Controls.Add(btnAddMachine);
            Controls.Add(welcomeLabel);
            Name = "UCHome";
            Size = new Size(863, 712);
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel welcomeLabel;
        private Sunny.UI.UIButton btnAddMachine;
        private Sunny.UI.UIButton btnAddRoute;
        private PictureBox imgLogo;
    }
}