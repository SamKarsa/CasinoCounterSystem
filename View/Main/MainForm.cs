using CasinoCounterSystem.View.Home;
using CasinoCounterSystem.View.Machine;
using CasinoCounterSystem.View.Route;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasinoCounterSystem.View
{
    public partial class MainForm : Form
    {

        private UCHome ucHome;

        // Para controlar la expansión de rutas
        private Dictionary<int, bool> routeExpandedStates = new Dictionary<int, bool>();
        private Dictionary<int, List<UIButton>> routeMachineButtons = new Dictionary<int, List<UIButton>>();

        public MainForm()
        {
            InitializeComponent();

            // SOLO esta línea
            this.AutoScaleMode = AutoScaleMode.None;

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Crear instancia de UCHome y suscribirse a sus eventos
            ucHome = new UCHome();
            ucHome.AddMachineClicked += UcHome_AddMachineClicked!;
            ucHome.AddRouteClicked += UcHome_AddRouteClicked!;

            // Suscribir evento al botón Home del sidebar
            btnHome.Click += BtnHome_Click!;

            // Cargar la vista Home inicial
            LoadView(ucHome);
        }

        private void UcHome_AddMachineClicked(object sender, EventArgs e)
        {
            // Crear instancia de UCMachineCreate y suscribirse a sus eventos
            var ucMachineCreate = new UCMachineCreate();
            ucMachineCreate.CancelClicked += (s, args) => LoadView(ucHome);
            ucMachineCreate.MachineCreated += (s, args) =>
            {
                // Aquí puedes mostrar un mensaje de éxito y volver al Home
                MessageBox.Show("Machine created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadView(ucHome);
            };

            LoadView(ucMachineCreate);
        }

        private void UcHome_AddRouteClicked(object sender, EventArgs e)
        {
            // Crear instancia de UCRouteCreate y suscribirse a sus eventos
            var ucRouteCreate = new UCRouteCreate();
            ucRouteCreate.CancelClicked += (s, args) => LoadView(ucHome);
            ucRouteCreate.RouteCreated += (s, args) =>
            {
                // Aquí puedes mostrar un mensaje de éxito y volver al Home
                MessageBox.Show("Route created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadView(ucHome);
            };

            LoadView(ucRouteCreate);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            // Volver a la vista Home
            LoadView(ucHome);
        }

        private void btnRegisterCounters_Click(object sender, EventArgs e)
        {
            FrmCounterRecord frmCounterRecord = new FrmCounterRecord();
            frmCounterRecord.Show();
        }

        private void LoadView(UserControl uc)
        {
            panelRight.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelRight.Controls.Add(uc);
        }
    }
}
