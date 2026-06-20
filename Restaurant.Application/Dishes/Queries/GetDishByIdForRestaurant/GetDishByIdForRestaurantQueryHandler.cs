using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishes.Queries.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQueryHandler(ILogger<GetDishByIdForRestaurantQueryHandler> logger,IResutaurantRepository resutaurantRepository,IDishRepository dishRepository, IMapper mapper)
        : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dish: @{DishId}, for restaurant with id: @{RestaurantId}",
            request.DishId,request.RestaurantId);
            
            var restaurant = await resutaurantRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Resturant), request.RestaurantId.ToString());
            }

            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if (dish == null) 
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());

            var result = mapper.Map<DishDto>(dish);
            return result;
        }
    }
}
