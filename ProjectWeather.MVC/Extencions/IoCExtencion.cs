using ProjectWeather.Infrastructure.Services;

namespace ProjectWeather.MVC.Extencions
{
    public static class IoCExtencion
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<HttpClientService>();
            return services;
        }
    }
}
