namespace CasinoCounterSystem.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            sidebarPanel = new Panel();
            panel1 = new Panel();
            lineBtnRegisterCounter = new Sunny.UI.UILine();
            btnHome = new Sunny.UI.UIButton();
            btnRegisterCounters = new Sunny.UI.UIButton();
            lineLogo = new Sunny.UI.UILine();
            logoLabel2 = new Sunny.UI.UILabel();
            logoLabel1 = new Sunny.UI.UILabel();
            btnAddMachine = new Panel();
            welcomeLabel = new Sunny.UI.UILabel();
            uiButton1 = new Sunny.UI.UIButton();
            btnAddRoute = new Sunny.UI.UIButton();
            pictureBox1 = new PictureBox();
            sidebarPanel.SuspendLayout();
            btnAddMachine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.Navy;
            sidebarPanel.Controls.Add(panel1);
            sidebarPanel.Controls.Add(lineBtnRegisterCounter);
            sidebarPanel.Controls.Add(btnHome);
            sidebarPanel.Controls.Add(btnRegisterCounters);
            sidebarPanel.Controls.Add(lineLogo);
            sidebarPanel.Controls.Add(logoLabel2);
            sidebarPanel.Controls.Add(logoLabel1);
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(251, 707);
            sidebarPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(257, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 254);
            panel1.TabIndex = 1;
            // 
            // lineBtnRegisterCounter
            // 
            lineBtnRegisterCounter.BackColor = Color.Transparent;
            lineBtnRegisterCounter.Font = new Font("Microsoft Sans Serif", 12F);
            lineBtnRegisterCounter.ForeColor = Color.Transparent;
            lineBtnRegisterCounter.LineColor = Color.White;
            lineBtnRegisterCounter.Location = new Point(12, 214);
            lineBtnRegisterCounter.MinimumSize = new Size(1, 1);
            lineBtnRegisterCounter.Name = "lineBtnRegisterCounter";
            lineBtnRegisterCounter.Size = new Size(222, 16);
            lineBtnRegisterCounter.TabIndex = 6;
            // 
            // btnHome
            // 
            btnHome.FillColor = Color.Transparent;
            btnHome.FillColor2 = Color.Transparent;
            btnHome.FillDisableColor = Color.Transparent;
            btnHome.Font = new Font("Microsoft Sans Serif", 12F);
            btnHome.ForeDisableColor = Color.FromArgb(156, 163, 175);
            btnHome.Location = new Point(12, 132);
            btnHome.MinimumSize = new Size(1, 1);
            btnHome.Name = "btnHome";
            btnHome.RectColor = Color.White;
            btnHome.RectDisableColor = Color.FromArgb(209, 213, 219);
            btnHome.RectHoverColor = Color.Gainsboro;
            btnHome.RectPressColor = Color.DarkGray;
            btnHome.RectSelectedColor = Color.White;
            btnHome.Size = new Size(222, 35);
            btnHome.TabIndex = 5;
            btnHome.Text = "🏠 Home";
            btnHome.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnHome.Click += uiButton2_Click;
            // 
            // btnRegisterCounters
            // 
            btnRegisterCounters.BackColor = Color.White;
            btnRegisterCounters.FillColor = Color.White;
            btnRegisterCounters.FillColor2 = Color.White;
            btnRegisterCounters.FillDisableColor = SystemColors.ButtonFace;
            btnRegisterCounters.FillHoverColor = Color.FromArgb(242, 244, 247);
            btnRegisterCounters.FillPressColor = Color.FromArgb(229, 231, 235);
            btnRegisterCounters.FillSelectedColor = Color.FromArgb(229, 231, 235);
            btnRegisterCounters.Font = new Font("Microsoft Sans Serif", 12F);
            btnRegisterCounters.ForeColor = Color.Navy;
            btnRegisterCounters.ForeDisableColor = Color.FromArgb(107, 114, 128);
            btnRegisterCounters.ForeHoverColor = Color.Navy;
            btnRegisterCounters.ForePressColor = Color.Navy;
            btnRegisterCounters.Location = new Point(12, 173);
            btnRegisterCounters.MinimumSize = new Size(1, 1);
            btnRegisterCounters.Name = "btnRegisterCounters";
            btnRegisterCounters.RectColor = Color.White;
            btnRegisterCounters.RectDisableColor = Color.Navy;
            btnRegisterCounters.RectHoverColor = Color.White;
            btnRegisterCounters.RectPressColor = Color.White;
            btnRegisterCounters.RectSelectedColor = Color.White;
            btnRegisterCounters.Size = new Size(222, 35);
            btnRegisterCounters.TabIndex = 1;
            btnRegisterCounters.Text = "📊 Register Counters";
            btnRegisterCounters.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // lineLogo
            // 
            lineLogo.BackColor = Color.Transparent;
            lineLogo.Font = new Font("Microsoft Sans Serif", 12F);
            lineLogo.ForeColor = Color.Transparent;
            lineLogo.LineColor = Color.White;
            lineLogo.Location = new Point(12, 110);
            lineLogo.MinimumSize = new Size(1, 1);
            lineLogo.Name = "lineLogo";
            lineLogo.Size = new Size(222, 16);
            lineLogo.TabIndex = 4;
            // 
            // logoLabel2
            // 
            logoLabel2.Font = new Font("Broadway", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logoLabel2.ForeColor = Color.White;
            logoLabel2.Location = new Point(70, 82);
            logoLabel2.Name = "logoLabel2";
            logoLabel2.Size = new Size(192, 35);
            logoLabel2.TabIndex = 3;
            logoLabel2.Text = "Electronic";
            logoLabel2.Click += logoLabel2_Click;
            // 
            // logoLabel1
            // 
            logoLabel1.Font = new Font("Broadway", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoLabel1.ForeColor = Color.White;
            logoLabel1.Location = new Point(12, 18);
            logoLabel1.Name = "logoLabel1";
            logoLabel1.Size = new Size(177, 77);
            logoLabel1.TabIndex = 2;
            logoLabel1.Text = "CLT";
            // 
            // btnAddMachine
            // 
            btnAddMachine.BackColor = Color.White;
            btnAddMachine.Controls.Add(welcomeLabel);
            btnAddMachine.Controls.Add(uiButton1);
            btnAddMachine.Controls.Add(btnAddRoute);
            btnAddMachine.Controls.Add(pictureBox1);
            btnAddMachine.Location = new Point(231, -19);
            btnAddMachine.Name = "btnAddMachine";
            btnAddMachine.Size = new Size(865, 726);
            btnAddMachine.TabIndex = 1;
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = AnchorStyles.None;
            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.Font = new Font("Microsoft Sans Serif", 16F);
            welcomeLabel.ForeColor = Color.Gray;
            welcomeLabel.Location = new Point(212, 267);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(500, 150);
            welcomeLabel.TabIndex = 9;
            welcomeLabel.Text = "Select an option from the sidebar\nto get started with your\nCasino Counter System";
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            uiButton1.BackColor = Color.White;
            uiButton1.FillColor = Color.Navy;
            uiButton1.FillColor2 = Color.Navy;
            uiButton1.FillDisableColor = Color.FromArgb(229, 231, 235);
            uiButton1.FillHoverColor = Color.FromArgb(30, 58, 138);
            uiButton1.FillPressColor = Color.FromArgb(0, 0, 102);
            uiButton1.FillSelectedColor = Color.FromArgb(30, 64, 175);
            uiButton1.Font = new Font("Microsoft Sans Serif", 12F);
            uiButton1.ForeDisableColor = Color.FromArgb(156, 163, 175);
            uiButton1.Location = new Point(559, 37);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.RectColor = Color.Navy;
            uiButton1.RectDisableColor = Color.FromArgb(209, 213, 219);
            uiButton1.RectHoverColor = Color.FromArgb(30, 58, 138);
            uiButton1.RectPressColor = Color.FromArgb(0, 0, 102);
            uiButton1.RectSelectedColor = Color.FromArgb(30, 64, 175);
            uiButton1.Size = new Size(143, 35);
            uiButton1.TabIndex = 8;
            uiButton1.Text = "➕ Add Machine";
            uiButton1.TipsFont = new Font("Microsoft Sans Serif", 9F);
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
            btnAddRoute.Location = new Point(708, 37);
            btnAddRoute.MinimumSize = new Size(1, 1);
            btnAddRoute.Name = "btnAddRoute";
            btnAddRoute.RectColor = Color.Navy;
            btnAddRoute.RectDisableColor = Color.FromArgb(209, 213, 219);
            btnAddRoute.RectHoverColor = Color.FromArgb(30, 58, 138);
            btnAddRoute.RectPressColor = Color.FromArgb(0, 0, 102);
            btnAddRoute.RectSelectedColor = Color.FromArgb(30, 64, 175);
            btnAddRoute.Size = new Size(143, 35);
            btnAddRoute.TabIndex = 2;
            btnAddRoute.Text = "🛣️ Add Route";
            btnAddRoute.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(773, 640);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(89, 86);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 707);
            Controls.Add(sidebarPanel);
            Controls.Add(btnAddMachine);
            Name = "MainForm";
            Text = "MainForm";
            sidebarPanel.ResumeLayout(false);
            btnAddMachine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel sidebarPanel;
        private Sunny.UI.UILabel logoLabel2;
        private Sunny.UI.UILabel logoLabel1;
        private Sunny.UI.UIButton btnRegisterCounters;
        private Sunny.UI.UILine lineLogo;
        private Sunny.UI.UIButton btnHome;
        private Sunny.UI.UILine lineBtnRegisterCounter;
        private Panel panel1;
        private Panel btnAddMachine;
        private PictureBox pictureBox1;
        private Sunny.UI.UIButton btnAddRoute;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UILabel welcomeLabel;
    }
}