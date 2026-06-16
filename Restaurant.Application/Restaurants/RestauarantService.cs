using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants
{
    public class RestauarantService(IResutaurantRepository resutaurantRepository,ILogger<RestauarantService> logger, IMapper mapper)
        : IRestauarantService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await resutaurantRepository.GetAllAsync();
            var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantDtos!;
        }

        public async Task<RestaurantDto?> GetById(int id)
        {
            logger.LogInformation($"Getting restaurant {id}");
            var restaurant = await resutaurantRepository.GetByIdAsync(id);
            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

            return restaurantDto;

        }
    }
}
