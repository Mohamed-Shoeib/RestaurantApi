using MediatR;
using Restaurant.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {
    }
}
