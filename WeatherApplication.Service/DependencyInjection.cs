using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Domain.DataAccessService;
using WeatherApplication.Infrastructure.DataAccessService;

namespace WeatherApplication.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
            return services;
        }
    }
}