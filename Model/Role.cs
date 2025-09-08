using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Model
{
    public class Role
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        [StringLength(100, ErrorMessage = "Role name cannot exceed 100 characters")]
        public string RoleName { get; set; } = string.Empty;

        // Constructor
        public Role() { }

        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public override string ToString()
        {
            return RoleName;
        }
    }
}
