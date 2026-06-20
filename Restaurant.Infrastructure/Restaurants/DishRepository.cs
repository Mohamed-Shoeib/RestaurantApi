using Restaurant.Domain.Entities;
using Restaurant.Domain.Repsitories;
using Restaurant.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Restaurants
{
    public class DishRepository(RestaurantDbContext dbContext) : IDishRepository
    {
        public async Task<int> Create(Dish dish)
        {
            dbContext.Dishes.Add(dish);
            await dbContext.SaveChangesAsync();
            return dish.Id;
        }

        public async Task Delete(IEnumerable<Dish> entities)
        {
            dbContext.RemoveRange(entities);
            await dbContext.SaveChangesAsync();
        }
    }
}
