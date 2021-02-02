using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countdown_ASP.NET.Models
{
    public class ProductVendor
    {
        public int Id { get; set; }

        public UserRole Role { get; set; }

        public int RoleId { get; set; } // User Role is automatically determined as "Owner"

        public string Name { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public List<Product> Products { get; set; }
    }
}
