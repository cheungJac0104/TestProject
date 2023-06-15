

namespace TestProject.Service.Weather
{
    public class WeatherService
    {

        public static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public Task<ResponseDto> GetWeather()
        {
            return Task.Run(() =>
            {
                List<WeatherForecast> _data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
 
                return ResponseDto.ReturnSuccess(obj: _data);
            });
        }


    }
}