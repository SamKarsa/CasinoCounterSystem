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

namespace CasinoCounterSystem.View.Machine
{
    public partial class UCMachineDetail : UserControl
    {
        private readonly MachineController machineController = new MachineController();
        private readonly CounterRecordController counterRecordController = new CounterRecordController();
        private int machineId;

        public UCMachineDetail(int machineId)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.machineId = machineId;

            LoadMachineData();
        }

        private void LoadMachineData()
        {
            var machine = machineController.GetMachineById(machineId);
            if (machine != null)
            {
                lblMachineNumber.Text = machine.NumberMachine;

                lblTypeMachine.Text = machine.TypeMachine?.NameTypeMachine
                                      ?? machine.TypeMachineId.ToString();

                lblCoinType.Text = machine.CoinType?.NumCoin != null
                                   ? $"${machine.CoinType.NumCoin}"
                                   : machine.CoinTypeId.ToString();
            }

            var records = counterRecordController.GetCounterRecordsByMachine(machineId);
            dataGridView1.DataSource = records;
        }
    }
}
