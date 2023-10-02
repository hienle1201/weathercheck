using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Domain.DataAccessService;
using WeatherApplication.Fatory;

namespace WeatherApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("FetchWeatherData")]
        public async Task<IActionResult> FetchWeatherData(string zipCode, CancellationToken ct)
        {
            var data = await _weatherService.FetchWeatherAsync(zipCode, ct);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(ApplicationFactory.CreateSuccessResponse(data));
        }
    }
}