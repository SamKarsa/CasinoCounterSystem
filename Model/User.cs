using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Model
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
        public string UserPassword { get; set; } = string.Empty;

        public bool UserStatus { get; set; } = true; // Active by default

        [Required(ErrorMessage = "Role is required")]
        public int RoleId { get; set; }

        // Navigation property (optional, useful for displaying data)
        public Role? Role { get; set; }

        // Constructor
        public User() { }

        public User(string userName, string password, int roleId)
        {
            UserName = userName;
            UserPassword = password;
            RoleId = roleId;
            UserStatus = true;
        }

        public override string ToString()
        {
            return $"{UserName} ({(UserStatus ? "Active" : "Inactive")})";
        }
    }
}
