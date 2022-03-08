using BulkInsertUsingEntityFrameworkCoreSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkInsertUsingEntityFrameworkCoreSample.Controllers
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
        private readonly MySqlDbContext _mySqlDbContext;
        private readonly PostgreSqlDbContext _postgreSqlDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MySqlDbContext mySqlDbContext, PostgreSqlDbContext postgreSqlDbContext)
        {
            _logger = logger;
            _mySqlDbContext = mySqlDbContext;
            _postgreSqlDbContext = postgreSqlDbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _mySqlDbContext.GuidKeyModels.Add(new GuidKeyModel());
            _mySqlDbContext.GuidKeyModels.Add(new GuidKeyModel());
            _mySqlDbContext.IntKeyModels.Add(new IntKeyModel());
            _mySqlDbContext.IntKeyModels.Add(new IntKeyModel());
            _mySqlDbContext.SaveChanges();

            _postgreSqlDbContext.GuidKeyModels.Add(new GuidKeyModel());
            _postgreSqlDbContext.GuidKeyModels.Add(new GuidKeyModel());
            _postgreSqlDbContext.IntKeyModels.Add(new IntKeyModel());
            _postgreSqlDbContext.IntKeyModels.Add(new IntKeyModel());
            _postgreSqlDbContext.SaveChanges();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}