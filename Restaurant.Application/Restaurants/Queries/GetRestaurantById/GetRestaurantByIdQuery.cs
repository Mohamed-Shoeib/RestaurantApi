using MediatR;
using Restaurant.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto>
    {
        public int Id { get; set; } = id;
    }
}
