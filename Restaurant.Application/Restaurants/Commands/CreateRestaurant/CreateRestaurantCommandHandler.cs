using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(IResutaurantRepository resutaurantRepository, ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper)
        : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = mapper.Map<Resturant>(request);
            var AddRestaurant = await resutaurantRepository.CreateAsync(restaurant);
            logger.LogInformation("Creating a new restaurant {@Restaurant}", request);
            return AddRestaurant;
        }
    }
}
