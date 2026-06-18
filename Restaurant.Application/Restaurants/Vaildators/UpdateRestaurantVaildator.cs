using FluentValidation;
using Restaurant.Application.Restaurants.Commands.UpdateRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants.Vaildators
{
    public class UpdateRestaurantVaildator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantVaildator()
        {
            RuleFor(c => c.Name)
                .Length(3, 100);
        }
    }
}
