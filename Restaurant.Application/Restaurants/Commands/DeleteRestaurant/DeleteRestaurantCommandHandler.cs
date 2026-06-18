using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Queries.GetRestaurantById;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(IResutaurantRepository resutaurantRepository, ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper)
        : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restaurant with id: {RestaurantId}", request.Id);
            var resturant = await resutaurantRepository.GetByIdAsync(request.Id);
            if(resturant is null)
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            await resutaurantRepository.Delete(resturant);
        }
    }
}
