using Microsoft.AspNetCore.Mvc;

namespace FreeMeanSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
            return Enumerable.Range(1, 5).Select(index =>
            {
                int temperatureC = Random.Shared.Next(-20, 55);
                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = temperatureC,
                    //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                    Summary = weatherSummary(temperatureC)
                };
            })
            .ToArray();
        }

        private string weatherSummary(int Temperature)
        {
            string summary = string.Empty;
            if (Temperature >= 17)
            {
                summary = Summaries.Single(s => s == "Warm");
            }
            else
            {
                summary = Summaries.Single(s => s == "Cool");
            }
                
            return summary;
        }
    }
}
