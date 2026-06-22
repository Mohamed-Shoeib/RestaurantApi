using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IRestaurantAuthorizationService
    {
        bool Authorize(Resturant restaurant, ResourceOperation resourceOperation);
    }
}
