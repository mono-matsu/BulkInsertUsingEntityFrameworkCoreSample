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
        private readonly SqlServerDbContext _sqlServerDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MySqlDbContext mySqlDbContext, PostgreSqlDbContext postgreSqlDbContext, SqlServerDbContext sqlServerDbContext)
        {
            _logger = logger;
            _mySqlDbContext = mySqlDbContext;
            _postgreSqlDbContext = postgreSqlDbContext;
            _sqlServerDbContext = sqlServerDbContext;
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

            _sqlServerDbContext.GuidKeyModels.Add(new GuidKeyModel());
            _sqlServerDbContext.GuidKeyModels.Add(new GuidKeyModel());
            _sqlServerDbContext.IntKeyModels.Add(new IntKeyModel());
            _sqlServerDbContext.IntKeyModels.Add(new IntKeyModel());
            _sqlServerDbContext.SaveChanges();

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