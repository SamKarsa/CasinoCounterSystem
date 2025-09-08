using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CasinoCounterSystem.View.Home
{
    public partial class UCHome : UserControl
    {

        // Eventos para comunicarse con el MainForm
        public event EventHandler? AddMachineClicked;
        public event EventHandler? AddRouteClicked;

        public UCHome()
        {
            InitializeComponent();

            // Suscribir eventos a los botones
            btnAddMachine.Click += BtnAddMachine_Click!;
            btnAddRoute.Click += BtnAddRoute_Click!;
        }

        private void BtnAddMachine_Click(object sender, EventArgs e)
        {
            // Disparar el evento para notificar al MainForm
            AddMachineClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnAddRoute_Click(object sender, EventArgs e)
        {
            // Disparar el evento para notificar al MainForm
            AddRouteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
