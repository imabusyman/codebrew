// Ignore Spelling: Api

using CodeBrew.LetsTravelIt.Api;
using CodeBrew.LetsTravelIt.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBrew.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoCodeController : ControllerBase
    {
        #region Private Fields

        private static readonly string[] Summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<GeoCodeController> _logger;

        #endregion Private Fields

        #region Public Constructors

        public GeoCodeController(ILogger<GeoCodeController> logger)
        {
            _logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet(Name = "GetCoordinates")]
        public IEnumerable<WeatherForecast> GetCoordinates(string address)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        #endregion Public Methods
    }
}