using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Restaurants
{
    public interface IRestauarantService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        Task<RestaurantDto?> GetById(int id);
    }
        
}