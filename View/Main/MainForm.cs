using CasinoCounterSystem.View.Home;
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
        public MainForm()
        {
            InitializeComponent();


            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            LoadView(new UCHome());
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
