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
    public partial class UCMachineCreate : UserControl
    {

        // Eventos para comunicarse con el MainForm
        public event EventHandler CancelClicked;
        public event EventHandler MachineCreated;

        public UCMachineCreate()
        {
            InitializeComponent();

            // Suscribir eventos a los botones
            btnCancelRoute.Click += BtnCancel_Click;
            btnSaveRoute.Click += BtnSave_Click;
        }
        

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para guardar la máquina
            // Por ejemplo, validar campos, guardar en base de datos, etc.

            // Una vez guardado exitosamente, disparar el evento
            MachineCreated?.Invoke(this, EventArgs.Empty);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Disparar el evento para volver al Home
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
