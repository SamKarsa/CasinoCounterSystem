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
            sidebarPanel = new Panel();
            panel1 = new Panel();
            lineBtnRegisterCounter = new Sunny.UI.UILine();
            btnHome = new Sunny.UI.UIButton();
            btnRegisterCounters = new Sunny.UI.UIButton();
            lineLogo = new Sunny.UI.UILine();
            logoLabel2 = new Sunny.UI.UILabel();
            logoLabel1 = new Sunny.UI.UILabel();
            panelRight = new Panel();
            btnLogOut = new Sunny.UI.UIButton();
            sidebarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.Navy;
            sidebarPanel.Controls.Add(btnLogOut);
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
            btnRegisterCounters.Click += btnRegisterCounters_Click;
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
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Location = new Point(240, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(856, 707);
            panelRight.TabIndex = 1;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.White;
            btnLogOut.FillColor = Color.White;
            btnLogOut.FillColor2 = Color.White;
            btnLogOut.FillDisableColor = SystemColors.ButtonFace;
            btnLogOut.FillHoverColor = Color.FromArgb(242, 244, 247);
            btnLogOut.FillPressColor = Color.FromArgb(229, 231, 235);
            btnLogOut.FillSelectedColor = Color.FromArgb(229, 231, 235);
            btnLogOut.Font = new Font("Microsoft Sans Serif", 12F);
            btnLogOut.ForeColor = Color.Navy;
            btnLogOut.ForeDisableColor = Color.FromArgb(107, 114, 128);
            btnLogOut.ForeHoverColor = Color.Navy;
            btnLogOut.ForePressColor = Color.Navy;
            btnLogOut.Location = new Point(12, 660);
            btnLogOut.MinimumSize = new Size(1, 1);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.RectColor = Color.White;
            btnLogOut.RectDisableColor = Color.Navy;
            btnLogOut.RectHoverColor = Color.White;
            btnLogOut.RectPressColor = Color.White;
            btnLogOut.RectSelectedColor = Color.White;
            btnLogOut.Size = new Size(222, 35);
            btnLogOut.TabIndex = 7;
            btnLogOut.Text = "🔚 LogOut";
            btnLogOut.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1094, 707);
            Controls.Add(sidebarPanel);
            Controls.Add(panelRight);
            MaximumSize = new Size(1110, 746);
            MinimumSize = new Size(1110, 746);
            Name = "MainForm";
            Text = "MainForm";
            sidebarPanel.ResumeLayout(false);
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
        private Panel panelRight;
        private Sunny.UI.UIButton btnLogOut;
    }
}