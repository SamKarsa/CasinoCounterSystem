using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Model
{
    public class TypeMachine
    {
        public int TypeMachineId { get; set; }

        [Required(ErrorMessage = "The machine type name is required")]
        [StringLength(50, ErrorMessage = "The type name cannot exceed 50 characters")]
        public string NameTypeMachine { get; set; } = string.Empty;

        // Constructor
        public TypeMachine() { }

        public TypeMachine(string nameTypeMachine)
        {
            NameTypeMachine = nameTypeMachine;
        }

        public override string ToString()
        {
            return NameTypeMachine;
        }

    }
}
