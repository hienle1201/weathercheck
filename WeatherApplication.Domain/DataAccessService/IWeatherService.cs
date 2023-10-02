using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApplication.Domain.Model;

namespace WeatherApplication.Domain.DataAccessService
{
    public interface IWeatherService
    {
        Task<WetherDataModel> FetchWeatherAsync(string zipCode, CancellationToken cancellationToken = default);
    }
}
