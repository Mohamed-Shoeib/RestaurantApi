using Microsoft.EntityFrameworkCore;
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
    public class RestuarantRepository(RestaurantDbContext dbContext) : IResutaurantRepository
    {
        public async Task<int> CreateAsync(Resturant resturant)
        {
            dbContext.Restaurants.Add(resturant);
            await dbContext.SaveChangesAsync();
            return resturant.Id;
        }
        public  async Task<IEnumerable<Resturant>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants
                                             .Include(d => d.Dishes)
                                             .ToListAsync();
            return restaurants;
        }
        public async Task<Resturant?> GetByIdAsync(int id)
        {
            var restaurant = await dbContext.Restaurants
                                            .Include(d => d.Dishes)
                                            .FirstOrDefaultAsync(r => r.Id == id);
            return restaurant;
        }
        public async Task Delete(Resturant entitiy)
        {
           dbContext.Remove(entitiy);
           await dbContext.SaveChangesAsync();
        }
        public Task SaveChanges()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
