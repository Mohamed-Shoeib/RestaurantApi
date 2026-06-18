using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(IResutaurantRepository resutaurantRepository, ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper)
        : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting restaurant {RestaurantId}", request.Id);
            var restaurant = await resutaurantRepository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
            return restaurantDto;
        }
    }
}
