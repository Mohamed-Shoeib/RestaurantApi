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

namespace Restaurant.Application.Dishes.Commands.DeleteDish
{
    public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> logger,
    IResutaurantRepository restaurantsRepository,
    IDishRepository dishesRepository)
        : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Removing all dishes from restaurant: {RestaurantId}", request.RestaurantId);
            var restauarnt = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if(restauarnt == null)
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            await dishesRepository.Delete(restauarnt.Dishes);
        }
    }
}
