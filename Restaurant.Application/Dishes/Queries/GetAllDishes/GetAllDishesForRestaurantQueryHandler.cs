using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishes.Queries.GetAllDishes
{
    public class GetAllDishesForRestaurantQueryHandler(ILogger<GetAllDishesForRestaurantQueryHandler> logger, IResutaurantRepository resutaurantRepository , IDishRepository dishRepository, IMapper mapper)
        : IRequestHandler<GetAllDishesForRestaurantQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetAllDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dishes for restaurant with id: {RestaurantId}", request.RestaurantId);
            var restaurant = await resutaurantRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var results = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

            return results;
        }
    }
}
