using System;
using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;

namespace CasinoCounterSystem.View
{
    public partial class MainForm1 : Form
    {
        private UIButton activeButton = null;

        public MainForm1()
        {
            InitializeComponent();
            SetupButtonStyles();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Configuración inicial del formulario
            this.Text = "CLT Electronic - Casino Counter System";

            // Mostrar panel de bienvenida por defecto
            ShowWelcomeContent();
        }

        private void SetupButtonStyles()
        {
            // Configurar estilo base para todos los botones
            var buttons = new[] { btnAddMachine, btnAddRoute, btnRegisterCounters,
                                btnMachines, btnRoutes, btnCounters, btnReports };

            foreach (UIButton button in buttons)
            {
                button.FillColor = Color.FromArgb(80, 160, 255);
                button.FillHoverColor = Color.FromArgb(115, 179, 255);
                button.FillPressColor = Color.FromArgb(64, 128, 204);
                button.RectColor = Color.FromArgb(80, 160, 255);
                button.RectHoverColor = Color.FromArgb(115, 179, 255);
                button.RectPressColor = Color.FromArgb(64, 128, 204);
                button.ForeColor = Color.White;
                button.Radius = 5;
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Padding = new Padding(20, 0, 0, 0);
            }
        }

        private void SetActiveButton(UIButton button)
        {
            // Resetear el botón anterior
            if (activeButton != null)
            {
                activeButton.FillColor = Color.FromArgb(80, 160, 255);
                activeButton.RectColor = Color.FromArgb(80, 160, 255);
            }

            // Establecer el nuevo botón activo
            activeButton = button;
            if (activeButton != null)
            {
                activeButton.FillColor = Color.FromArgb(64, 128, 204);
                activeButton.RectColor = Color.FromArgb(64, 128, 204);
            }
        }

        private void ClearMainContent()
        {
            // Limpiar el contenido del panel principal
            mainContentPanel.Controls.Clear();
        }

        private void ShowWelcomeContent()
        {
            ClearMainContent();
            mainContentPanel.Controls.Add(welcomePanel);
            SetActiveButton(null);
        }

        // Event Handlers para los botones principales
        private void BtnAddMachine_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnAddMachine);
            ShowAddMachineContent();
        }

        private void BtnAddRoute_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnAddRoute);
            ShowAddRouteContent();
        }

        private void BtnRegisterCounters_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnRegisterCounters);
            ShowRegisterCountersContent();
        }

        // Event Handlers para las categorías
        private void BtnMachines_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMachines);
            ShowMachinesContent();
        }

        private void BtnRoutes_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnRoutes);
            ShowRoutesContent();
        }

        private void BtnCounters_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnCounters);
            ShowCountersContent();
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnReports);
            ShowReportsContent();
        }

        // Métodos para mostrar diferentes contenidos
        private void ShowAddMachineContent()
        {
            ClearMainContent();

            UITitlePanel panel = new UITitlePanel()
            {
                Dock = DockStyle.Fill,
                Text = "Add New Machine",
                Font = new Font("Microsoft Sans Serif", 12F),
                Padding = new Padding(1, 35, 1, 1)
            };

            UILabel contentLabel = new UILabel()
            {
                Text = "Here you can add a new casino machine to the system.\n\nThis section will contain forms and controls\nto input machine details, location, and settings.",
                Font = new Font("Microsoft Sans Serif", 14F),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                AutoSize = false,
                Size = new Size(500, 200),
                Location = new Point(200, 200)
            };

            panel.Controls.Add(contentLabel);
            mainContentPanel.Controls.Add(panel);
        }

        private void ShowAddRouteContent()
        {
            ClearMainContent();

            UITitlePanel panel = new UITitlePanel()
            {
                Dock = DockStyle.Fill,
                Text = "Add New Route",
                Font = new Font("Microsoft Sans Serif", 12F),
                Padding = new Padding(1, 35, 1, 1)
            };

            UILabel contentLabel = new UILabel()
            {
                Text = "Here you can create new routes for machine collections.\n\nDefine the path, assign machines to routes,\nand set collection schedules.",
                Font = new Font("Microsoft Sans Serif", 14F),
                ForeColor = Color.DarkGreen,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                AutoSize = false,
                Size = new Size(500, 200),
                Location = new Point(200, 200)
            };

            panel.Controls.Add(contentLabel);
            mainContentPanel.Controls.Add(panel);
        }

        private void ShowRegisterCountersContent()
        {
            ClearMainContent();

            UITitlePanel panel = new UITitlePanel()
            {
                Dock = DockStyle.Fill,
                Text = "Register Counters",
                Font = new Font("Microsoft Sans Serif", 12F),
                Padding = new Padding(1, 35, 1, 1)
            };

            UILabel contentLabel = new UILabel()
            {
                Text = "Register and update counter readings from machines.\n\nInput daily counts, track earnings,\nand manage counter history.",
                Font = new Font("Microsoft Sans Serif", 14F),
                ForeColor = Color.DarkOrange,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                AutoSize = false,
                Size = new Size(500, 200),
                Location = new Point(200, 200)
            };

            panel.Controls.Add(contentLabel);
            mainContentPanel.Controls.Add(panel);
        }

        private void ShowMachinesContent()
        {
            ClearMainContent();

            UITitlePanel panel = new UITitlePanel()
            {
                Dock = DockStyle.Fill,
                Text = "Machines Management",
                Font = new Font("Microsoft Sans Serif", 12F),
                Padding = new Padding(1, 35, 1, 1)
            };

            UILabel contentLabel = new UILabel()
            {
                Text = "View and manage all casino machines in the system.\n\nEdit machine details, view status,\nand track performance history.",
                Font = new Font("Microsoft Sans Serif", 14F),
                ForeColor = Color.DarkRed,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                AutoSize = false,
                Size = new Size(500, 200),
                Location = new Point(200, 200)
            };

            panel.Controls.Add(contentLabel);
            mainContentPanel.Controls.Add(panel);
        }

        private void ShowRoutesContent()
        {
            ClearMainContent();

            UITitlePanel panel = new UITitlePanel()
            {
                Dock = DockStyle.Fill,
                Text = "Routes Management",
                Font = new Font("Microsoft Sans Serif", 12F),
                Padding = new Padding(1, 35, 1, 1)
            };

            UILabel contentLabel = new UILabel()
            {
                Text = "Manage collection routes and schedules.\n\nView route details, assign collectors,\nand optimize collection paths.",
                Font = new Font("Microsoft Sans Serif", 14F),
                ForeColor = Color.DarkMagenta,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                AutoSize = false,
                Size = new Size(500, 200),
                Location = new Point(200, 200)
            };

            panel.Controls.Add(contentLabel);
            mainContentPanel.Controls.Add(panel);
        }

        private void ShowCountersContent()
        {
            ClearMainContent();

            UITitlePanel panel = new UITitlePanel()
            {
                Dock = DockStyle.Fill,
                Text = "Counters Overview",
                Font = new Font("Microsoft Sans Serif", 12F),
                Padding = new Padding(1, 35, 1, 1)
            };

            UILabel contentLabel = new UILabel()
            {
                Text = "View all counter readings and history.\n\nAnalyze trends, track discrepancies,\nand generate counter reports.",
                Font = new Font("Microsoft Sans Serif", 14F),
                ForeColor = Color.DarkCyan,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                AutoSize = false,
                Size = new Size(500, 200),
                Location = new Point(200, 200)
            };

            panel.Controls.Add(contentLabel);
            mainContentPanel.Controls.Add(panel);
        }

        private void ShowReportsContent()
        {
            ClearMainContent();

            UITitlePanel panel = new UITitlePanel()
            {
                Dock = DockStyle.Fill,
                Text = "Reports & Analytics",
                Font = new Font("Microsoft Sans Serif", 12F),
                Padding = new Padding(1, 35, 1, 1)
            };

            UILabel contentLabel = new UILabel()
            {
                Text = "Generate comprehensive reports and analytics.\n\nView earnings summaries, performance metrics,\nand export data for analysis.",
                Font = new Font("Microsoft Sans Serif", 14F),
                ForeColor = Color.DarkSlateBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                AutoSize = false,
                Size = new Size(500, 200),
                Location = new Point(200, 200)
            };

            panel.Controls.Add(contentLabel);
            mainContentPanel.Controls.Add(panel);
        }
    }
}