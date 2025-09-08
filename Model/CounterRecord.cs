using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Model
{
    public class CounterRecord
    {
        public int CounterRecordId { get; set; }

        [Required(ErrorMessage = "Record date is required")]
        public DateTime RecordDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Entry counter is required")]
        [Range(0, long.MaxValue, ErrorMessage = "Entry counter must be positive")]
        public long CounterIn { get; set; }

        [Required(ErrorMessage = "Exit counter is required")]
        [Range(0, long.MaxValue, ErrorMessage = "Exit counter must be positive")]
        public long CounterOut { get; set; }

        [Required(ErrorMessage = "Total delivered is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total delivered must be positive")]
        public decimal TotalDelivered { get; set; }

        [Required(ErrorMessage = "Machine is required")]
        public int MachineId { get; set; }

        // Navigation property
        public Machine? Machine { get; set; }

        // Read-only calculated property
        public long NetCount => CounterOut - CounterIn;

        // Constructor
        public CounterRecord() { }

        public CounterRecord(DateTime recordDate, long counterIn, long counterOut, decimal totalDelivered, int machineId)
        {
            RecordDate = recordDate;
            CounterIn = counterIn;
            CounterOut = counterOut;
            TotalDelivered = totalDelivered;
            MachineId = machineId;
        }

        public override string ToString()
        {
            return $"Record {RecordDate:dd/MM/yyyy} - Machine {MachineId}";
        }
    }
}
