using Microsoft.AspNetCore.Mvc;

namespace RESTfulServicesDemo.Controllers
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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            return Ok();
        }

        [HttpPost("Body")]
        public IActionResult PostBody([FromBody]WeatherForecast weatherForecast)
        {
            return Ok(weatherForecast);
        }

        [HttpPost("Form")]
        public IActionResult PostForm([FromForm]WeatherForecast weatherForecast)
        {
            return Ok(weatherForecast);
        }

        [HttpPost("Route/{id}")]
        public IActionResult PostRoute([FromRoute] string id)
        {
            return Ok(id);
        }

        [HttpPost("Query")]
        public IActionResult PostQuery([FromQuery(Name ="Summary")] string summary)
        {
            return Ok(summary);
        }
    }
}