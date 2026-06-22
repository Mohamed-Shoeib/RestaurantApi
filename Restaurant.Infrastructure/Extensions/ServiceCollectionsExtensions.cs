using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Repsitories;
using Restaurant.Infrastructure.Authorization;
using Restaurant.Infrastructure.Authorization.Requirements;
using Restaurant.Infrastructure.Authorization.Services;
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
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<RestaurantsUserClaimsPrincipalFactory>()
                .AddEntityFrameworkStores<RestaurantDbContext>();

            services.AddAuthentication()
                .AddBearerToken();

            services.AddAuthorization();
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IResutaurantRepository, RestuarantRepository>();
            services.AddScoped<IDishRepository, DishRepository>();

            services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.HasNationality,
                builder => builder.RequireClaim(AppClaimTypes.Nationality, "German", "Polish"))

            .AddPolicy(PolicyNames.AtLeast20,
                builder => builder.AddRequirements(new MinimumAgeRequirement(20)))
            .AddPolicy(PolicyNames.CreatedAtleast2Restaurants,
                builder => builder.AddRequirements(new CreatedMultipleRestaurantsRequirement(2)));

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, CreatedMultipleRestaurantsRequirementHandler>();
            services.AddScoped<IRestaurantAuthorizationService, RestaurantAuthorizationService>();
        }
    }
}