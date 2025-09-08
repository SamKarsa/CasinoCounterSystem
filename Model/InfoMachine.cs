using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Model
{
    public class InfoMachine
    {
        public int InfoMachineId { get; set; } // This is FK to Machine

        [StringLength(100, ErrorMessage = "The client name cannot exceed 100 characters")]
        public string? NameClient { get; set; }

        [StringLength(20, ErrorMessage = "The phone number cannot exceed 20 characters")]
        public string? Phone { get; set; }

        [StringLength(150, ErrorMessage = "The address cannot exceed 150 characters")]
        public string? Address { get; set; }

        // Navigation property
        public Machine? Machine { get; set; }

        // Constructor
        public InfoMachine() { }

        public InfoMachine(int machineId, string? nameClient = null, string? phone = null, string? address = null)
        {
            InfoMachineId = machineId;
            NameClient = nameClient;
            Phone = phone;
            Address = address;
        }

        public override string ToString()
        {
            return NameClient ?? "No client assigned";
        }
    }
}
    