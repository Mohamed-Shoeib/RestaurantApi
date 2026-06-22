using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Application.Users;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(IResutaurantRepository resutaurantRepository, ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IUserContext userContext)
        : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();

            logger.LogInformation("{UserEmail} [{UserId}] is creating a new restaurant {@Restaurant}",
                currentUser.Email,
                currentUser.Id,
                request);
            var restaurant = mapper.Map<Resturant>(request);
            restaurant.OwnerId = currentUser.Id;
            var AddRestaurant = await resutaurantRepository.CreateAsync(restaurant);
            return AddRestaurant;
        }
    }
}
