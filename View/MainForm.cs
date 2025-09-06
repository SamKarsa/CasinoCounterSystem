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
        }

        private void btnRegisterCounters_Click(object sender, EventArgs e)
        {
            FrmCounterRecord frmCounterRecord = new FrmCounterRecord();
            frmCounterRecord.Show();
        }
    }
}
