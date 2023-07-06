using Microsoft.AspNetCore.Mvc;
using TestProject.Middleware.Policies;
using TestProject.Service.Weather;

namespace TestProject.Controllers;



[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private WeatherService _service;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherService service)
    {
        _logger = logger;
        _service = service;
    }


    [HttpGet("GetWeatherForecast")]
    [ClientAuthorize, StaffAuthorize]
    public Task<ResponseDto> Get()
    {

        return _service.GetWeather();
         
    }

    [HttpGet("GetTestCall")]
    public IActionResult Test()
    {
        return Ok();
    }






    
}


