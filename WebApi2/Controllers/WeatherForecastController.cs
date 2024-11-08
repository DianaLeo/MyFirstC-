using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
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
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("{id}")]
    // api/weatherforecast/getweatherforcast/1
    public WeatherForecast GetWeatherForecast(int id)
    {
        var weatherArr = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        if (id < 0 || id >= weatherArr.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid weather forecast ID.");
        }
        
        return weatherArr[id];
    }

    [HttpGet]
    //api/WeatherForecast/QueryStringParameters?id=1&name=diana
    public JsonResult QueryStringParameters(int id, string name) {   
        return new JsonResult(new {username = $"hello {name}"});
    }

    [HttpPost]
    // body - raw
    public JsonResult AddUser([FromBody] User user){
        return new JsonResult(user);
    }

    [HttpPost]
    // form-data: mimic html form submit
    public JsonResult AddUserFromForm([FromForm] User user){
        return new JsonResult(user);
    }
}
