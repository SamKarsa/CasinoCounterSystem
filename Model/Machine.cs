using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Model
{
    public class Machine
    {
        public int MachineId { get; set; }

        [Required(ErrorMessage = "Machine number is required")]
        [StringLength(50, ErrorMessage = "Machine number cannot exceed 50 characters")]
        public string NumberMachine { get; set; } = string.Empty;

        [Required(ErrorMessage = "Machine type is required")]
        public int TypeMachineId { get; set; }

        [Required(ErrorMessage = "Coin type is required")]
        public int CoinTypeId { get; set; }

        [Required(ErrorMessage = "Route is required")]
        public int RouteId { get; set; }

        // Navigation properties (optional, useful for displaying related data)
        public TypeMachine? TypeMachine { get; set; }
        public CoinType? CoinTypeObj { get; set; }
        public Route? Route { get; set; }
        public InfoMachine? InfoMachine { get; set; }

        // Constructor
        public Machine() { }

        public Machine(string numberMachine, int typeMachineId, int coinType, int routeId)
        {
            NumberMachine = numberMachine;
            TypeMachineId = typeMachineId;
            CoinType = coinType;
            RouteId = routeId;
        }

        public override string ToString()
        {
            return $"Machine {NumberMachine}";
        }
    }
}
