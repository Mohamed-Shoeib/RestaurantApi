using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRestauarantService, RestauarantService>();
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

        }

    }
}
