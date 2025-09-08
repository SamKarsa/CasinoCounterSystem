using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Model
{
    public class Route
    {
        public int RouteId { get; set; }

        [Required(ErrorMessage = "Route name is required")]
        [StringLength(50, ErrorMessage = "Route name cannot exceed 50 characters")]
        [MinLength(2, ErrorMessage = "Route name must be at least 2 characters")]
        public string RouteName { get; set; } = string.Empty;

        // Constructor
        public Route() { }

        public Route(string routeName)
        {
            RouteName = routeName;
        }

        public override string ToString()
        {
            return RouteName;
        }
    }
}
