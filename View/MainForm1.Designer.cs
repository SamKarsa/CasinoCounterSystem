namespace CasinoCounterSystem.View
{
    partial class MainForm1
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
            sidebarPanel = new Sunny.UI.UIPanel();
            logoLabel = new Sunny.UI.UILabel();
            btnAddMachine = new Sunny.UI.UIButton();
            btnAddRoute = new Sunny.UI.UIButton();
            btnRegisterCounters = new Sunny.UI.UIButton();
            categoriesLabel = new Sunny.UI.UILabel();
            btnMachines = new Sunny.UI.UIButton();
            btnRoutes = new Sunny.UI.UIButton();
            btnCounters = new Sunny.UI.UIButton();
            btnReports = new Sunny.UI.UIButton();
            mainContentPanel = new Sunny.UI.UIPanel();
            welcomePanel = new Sunny.UI.UITitlePanel();
            welcomeLabel = new Sunny.UI.UILabel();
            sidebarPanel.SuspendLayout();
            mainContentPanel.SuspendLayout();
            welcomePanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(48, 48, 48);
            sidebarPanel.Controls.Add(logoLabel);
            sidebarPanel.Controls.Add(btnAddMachine);
            sidebarPanel.Controls.Add(btnAddRoute);
            sidebarPanel.Controls.Add(btnRegisterCounters);
            sidebarPanel.Controls.Add(categoriesLabel);
            sidebarPanel.Controls.Add(btnMachines);
            sidebarPanel.Controls.Add(btnRoutes);
            sidebarPanel.Controls.Add(btnCounters);
            sidebarPanel.Controls.Add(btnReports);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.FillColor = Color.FromArgb(48, 48, 48);
            sidebarPanel.Font = new Font("Microsoft Sans Serif", 12F);
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Margin = new Padding(4, 5, 4, 5);
            sidebarPanel.MinimumSize = new Size(250, 1);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(250, 664);
            sidebarPanel.TabIndex = 0;
            sidebarPanel.Text = null;
            sidebarPanel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // logoLabel
            // 
            logoLabel.BackColor = Color.Transparent;
            logoLabel.Font = new Font("Arial", 18F, FontStyle.Bold);
            logoLabel.ForeColor = Color.White;
            logoLabel.Location = new Point(10, 20);
            logoLabel.Name = "logoLabel";
            logoLabel.Size = new Size(230, 50);
            logoLabel.TabIndex = 0;
            logoLabel.Text = "CLT ELECTRONIC";
            logoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddMachine
            // 
            btnAddMachine.Cursor = Cursors.Hand;
            btnAddMachine.Font = new Font("Microsoft Sans Serif", 11F);
            btnAddMachine.Location = new Point(15, 90);
            btnAddMachine.MinimumSize = new Size(1, 1);
            btnAddMachine.Name = "btnAddMachine";
            btnAddMachine.Size = new Size(220, 40);
            btnAddMachine.TabIndex = 1;
            btnAddMachine.Text = "➕ Add Machine";
            btnAddMachine.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnAddMachine.Click += BtnAddMachine_Click;
            // 
            // btnAddRoute
            // 
            btnAddRoute.Cursor = Cursors.Hand;
            btnAddRoute.Font = new Font("Microsoft Sans Serif", 11F);
            btnAddRoute.Location = new Point(15, 140);
            btnAddRoute.MinimumSize = new Size(1, 1);
            btnAddRoute.Name = "btnAddRoute";
            btnAddRoute.Size = new Size(220, 40);
            btnAddRoute.TabIndex = 2;
            btnAddRoute.Text = "🛣️ Add Route";
            btnAddRoute.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnAddRoute.Click += BtnAddRoute_Click;
            // 
            // btnRegisterCounters
            // 
            btnRegisterCounters.Cursor = Cursors.Hand;
            btnRegisterCounters.Font = new Font("Microsoft Sans Serif", 11F);
            btnRegisterCounters.Location = new Point(15, 190);
            btnRegisterCounters.MinimumSize = new Size(1, 1);
            btnRegisterCounters.Name = "btnRegisterCounters";
            btnRegisterCounters.Size = new Size(220, 40);
            btnRegisterCounters.TabIndex = 3;
            btnRegisterCounters.Text = "📊 Register Counters";
            btnRegisterCounters.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnRegisterCounters.Click += BtnRegisterCounters_Click;
            // 
            // categoriesLabel
            // 
            categoriesLabel.BackColor = Color.Transparent;
            categoriesLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            categoriesLabel.ForeColor = Color.LightGray;
            categoriesLabel.Location = new Point(15, 260);
            categoriesLabel.Name = "categoriesLabel";
            categoriesLabel.Size = new Size(220, 30);
            categoriesLabel.TabIndex = 4;
            categoriesLabel.Text = "CATEGORIES";
            categoriesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnMachines
            // 
            btnMachines.Cursor = Cursors.Hand;
            btnMachines.Font = new Font("Microsoft Sans Serif", 11F);
            btnMachines.Location = new Point(15, 300);
            btnMachines.MinimumSize = new Size(1, 1);
            btnMachines.Name = "btnMachines";
            btnMachines.Size = new Size(220, 40);
            btnMachines.TabIndex = 5;
            btnMachines.Text = "🎰 Machines";
            btnMachines.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnMachines.Click += BtnMachines_Click;
            // 
            // btnRoutes
            // 
            btnRoutes.Cursor = Cursors.Hand;
            btnRoutes.Font = new Font("Microsoft Sans Serif", 11F);
            btnRoutes.Location = new Point(15, 350);
            btnRoutes.MinimumSize = new Size(1, 1);
            btnRoutes.Name = "btnRoutes";
            btnRoutes.Size = new Size(220, 40);
            btnRoutes.TabIndex = 6;
            btnRoutes.Text = "📁 Routes";
            btnRoutes.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnRoutes.Click += BtnRoutes_Click;
            // 
            // btnCounters
            // 
            btnCounters.Cursor = Cursors.Hand;
            btnCounters.Font = new Font("Microsoft Sans Serif", 11F);
            btnCounters.Location = new Point(15, 400);
            btnCounters.MinimumSize = new Size(1, 1);
            btnCounters.Name = "btnCounters";
            btnCounters.Size = new Size(220, 40);
            btnCounters.TabIndex = 7;
            btnCounters.Text = "🔢 Counters";
            btnCounters.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnCounters.Click += BtnCounters_Click;
            // 
            // btnReports
            // 
            btnReports.Cursor = Cursors.Hand;
            btnReports.Font = new Font("Microsoft Sans Serif", 11F);
            btnReports.Location = new Point(15, 450);
            btnReports.MinimumSize = new Size(1, 1);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(220, 40);
            btnReports.TabIndex = 8;
            btnReports.Text = "📈 Reports";
            btnReports.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnReports.Click += BtnReports_Click;
            // 
            // mainContentPanel
            // 
            mainContentPanel.BackColor = Color.White;
            mainContentPanel.Controls.Add(welcomePanel);
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Font = new Font("Microsoft Sans Serif", 12F);
            mainContentPanel.Location = new Point(250, 0);
            mainContentPanel.Margin = new Padding(4, 5, 4, 5);
            mainContentPanel.MinimumSize = new Size(1, 1);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(896, 664);
            mainContentPanel.TabIndex = 1;
            mainContentPanel.Text = null;
            mainContentPanel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // welcomePanel
            // 
            welcomePanel.Controls.Add(welcomeLabel);
            welcomePanel.Dock = DockStyle.Fill;
            welcomePanel.Font = new Font("Microsoft Sans Serif", 12F);
            welcomePanel.Location = new Point(0, 0);
            welcomePanel.Margin = new Padding(4, 5, 4, 5);
            welcomePanel.MinimumSize = new Size(1, 1);
            welcomePanel.Name = "welcomePanel";
            welcomePanel.Padding = new Padding(1, 35, 1, 1);
            welcomePanel.ShowText = false;
            welcomePanel.Size = new Size(896, 664);
            welcomePanel.TabIndex = 0;
            welcomePanel.Text = "Welcome to CLT Electronic System";
            welcomePanel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = AnchorStyles.None;
            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.Font = new Font("Microsoft Sans Serif", 16F);
            welcomeLabel.ForeColor = Color.Gray;
            welcomeLabel.Location = new Point(215, 260);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(500, 150);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Select an option from the sidebar\nto get started with your\nCasino Counter System";
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 664);
            Controls.Add(mainContentPanel);
            Controls.Add(sidebarPanel);
            MinimumSize = new Size(800, 600);
            Name = "MainForm1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CLT Electronic - Casino Counter System";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            sidebarPanel.ResumeLayout(false);
            mainContentPanel.ResumeLayout(false);
            welcomePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel sidebarPanel;
        private Sunny.UI.UILabel logoLabel;
        private Sunny.UI.UIButton btnAddMachine;
        private Sunny.UI.UIButton btnAddRoute;
        private Sunny.UI.UIButton btnRegisterCounters;
        private Sunny.UI.UILabel categoriesLabel;
        private Sunny.UI.UIButton btnMachines;
        private Sunny.UI.UIButton btnRoutes;
        private Sunny.UI.UIButton btnCounters;
        private Sunny.UI.UIButton btnReports;
        private Sunny.UI.UIPanel mainContentPanel;
        private Sunny.UI.UITitlePanel welcomePanel;
        private Sunny.UI.UILabel welcomeLabel;
    }
}