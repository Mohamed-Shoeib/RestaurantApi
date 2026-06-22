using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? Nationality { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public List<Resturant> OwnedRestaurants { get; set; } = [];
    }
}
