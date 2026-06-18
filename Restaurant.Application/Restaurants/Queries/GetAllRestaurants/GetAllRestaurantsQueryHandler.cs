using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(IResutaurantRepository resutaurantRepository, ILogger<GetAllRestaurantsQueryHandler> logger, IMapper mapper)
        : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await resutaurantRepository.GetAllAsync();
            var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantDtos!;
        }
    }
}
