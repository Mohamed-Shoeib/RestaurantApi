using Microsoft.Extensions.Configuration;
using Restaurant.Api.Middlewares;
using Restaurant.Application.Extensions;
using Restaurant.Infrastructure.Extensions;
using Restaurant.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;

namespace Restaurant.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();
            builder.Host.UseSerilog((context, Configuration) =>
                    Configuration.ReadFrom.Configuration(context.Configuration));
                    
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<RequestTimeLoggingMiddleware>();
            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
            await seeder.Seed();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestTimeLoggingMiddleware>();
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
