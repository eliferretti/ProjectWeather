using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using ProjectWeather.API.Middlewares;
using ProjectWeather.Application.Helpers;
using ProjectWeather.Infrastructure.Data;
using ProjectWeather.Infrastructure.Interfaces;
using ProjectWeather.Infrastructure.Repositories;
using System.Globalization;
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

            //var connectionString = configuration.GetConnectionString("DefaultConnection");

            //services.AddDbContext<DataContext>(
            //    opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DataContext>();

            services.AddTransient<ErrorHandlerMiddleware>();

            services.AddScoped<IWeatherRepository, WeatherRepository>();

            services.AddAutoMapper(typeof(MapProfile));


            var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("pt-BR") };
            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = requestLocalizationOptions.DefaultRequestCulture;
                options.SupportedCultures = requestLocalizationOptions.SupportedCultures;
                options.SupportedUICultures = requestLocalizationOptions.SupportedUICultures;
            });
        }
    }
}
