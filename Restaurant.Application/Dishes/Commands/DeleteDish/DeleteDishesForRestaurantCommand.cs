using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishes.Commands.DeleteDish
{
    public class DeleteDishesForRestaurantCommand(int restaurantId) : IRequest
    {
        public int RestaurantId { get; set; } = restaurantId;
    }
}
