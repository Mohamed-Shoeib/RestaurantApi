using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence
{
    public class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Resturant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Resturant>()
                        .OwnsOne(r => r.Address);

            modelBuilder.Entity<Resturant>()
                .HasMany(r => r.Dishes)
                .WithOne(d => d.Restaurant)
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}
