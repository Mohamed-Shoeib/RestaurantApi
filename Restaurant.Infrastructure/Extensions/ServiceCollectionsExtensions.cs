using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repsitories;
using Restaurant.Infrastructure.Persistence;
using Restaurant.Infrastructure.Restaurants;
using Restaurant.Infrastructure.Seeders;

namespace Restaurant.Infrastructure.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RestaurantDb");

            services.AddDbContext<RestaurantDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<RestaurantDbContext>();

            services.AddAuthentication()
                .AddBearerToken();

            services.AddAuthorization();
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IResutaurantRepository, RestuarantRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
        }
    }
}