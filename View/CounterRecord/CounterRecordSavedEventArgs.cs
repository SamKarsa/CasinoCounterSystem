using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.View.CounterRecord
{
    public class CounterRecordSavedEventArgs : EventArgs
    {
        public int MachineId { get; }
        public int NewRecordId { get; }

        public CounterRecordSavedEventArgs(int machineId, int newRecordId)
        {
            MachineId = machineId;
            NewRecordId = newRecordId;
        }
    }
}
