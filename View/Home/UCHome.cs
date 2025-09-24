using CasinoCounterSystem.Controller;
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

        public event EventHandler? AddMachineClicked;
        public event EventHandler? AddRouteClicked;

        public UCHome()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;

            btnAddMachine.Click += BtnAddMachine_Click!;
            btnAddRoute.Click += BtnAddRoute_Click!;

            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            bool canCreate = SessionManager.IsAdmin;

            btnAddMachine.Enabled = canCreate;
            btnAddRoute.Enabled = canCreate;

            btnAddMachine.TabStop = canCreate;
            btnAddRoute.TabStop = canCreate;
        }


        private void BtnAddMachine_Click(object sender, EventArgs e)
        {
           
            AddMachineClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnAddRoute_Click(object sender, EventArgs e)
        {
            
            AddRouteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
