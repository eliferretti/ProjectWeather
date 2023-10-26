using Microsoft.EntityFrameworkCore;
using ProjectWeather.API.Middlewares;
using ProjectWeather.Application.Helpers;
using ProjectWeather.Infrastructure.Data;
using ProjectWeather.Infrastructure.Interfaces;
using ProjectWeather.Infrastructure.Repositories;
using System.Reflection;

namespace ProjectWeather.API.Extencions
{
    public static class IoCExtencion
    {
        public static void AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.Load("ProjectWeather.Application"));
            });

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(
                opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ErrorHandlerMiddleware>();

            services.AddScoped<IWeatherRepository, WeatherRepository>();

            services.AddAutoMapper(typeof(MapProfile));
        }
    }
}
