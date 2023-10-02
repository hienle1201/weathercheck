using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WeatherApplication.Domain.DataAccessService;
using WeatherApplication.Domain.Model;
using WeatherApplication.Domain.Options;

namespace WeatherApplication.Infrastructure.DataAccessService
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherService> _logger;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly ApplicationOptions _applicationOptions;

        public WeatherService(ILogger<WeatherService> logger, HttpClient httpClient, IOptions<ApplicationOptions> applicationOptions)
        {
            _logger = logger;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            _applicationOptions = applicationOptions.Value;
        }
        public async Task<WetherDataModel> FetchWeatherAsync(string zipCode, CancellationToken cancellationToken = default)
        {
            try
            {
                Dictionary<string, string> query = new Dictionary<string, string>();

                query.Add("access_key", _applicationOptions.WeatherProvider.AccessKey);
                query.Add("query", zipCode);


                var path = QueryHelpers.AddQueryString("/current", query); // this will do url encoding

                var uri = new Uri(_httpClient.BaseAddress!, path); // to resolve redundance "/" in BaseAddress
                var response = await _httpClient.GetAsync(uri);

                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError(
                        $"Failed to get data: " +
                        content);
                    return null;
                }

                var result = JsonSerializer.Deserialize<WetherDataModel>(content);
                if (result == null)
                    result = null;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Failed to get data: " +
                    ex.ToString());
            }

            return null;
        }
    }
}
