using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using WebApplication1.NewFolder;

namespace WebApplication1.Controllers
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

        [HttpGet]
        [Authorize]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetAll")]
        [Authorize]
        public IEnumerable<string> GetAll()
        {
            var user = HttpContext.User;
            var claims = ((System.Security.Claims.ClaimsIdentity)user.Identity).Claims;
            var items = claims.ToList();
            var jsonstr = items.Last().Value;
            var cham = items[3].Value;


            FirebaseIdentity fb = (FirebaseIdentity)JsonConvert.DeserializeObject(jsonstr, typeof(FirebaseIdentity));
            //**** get the user email address here ***
            var useremail = fb.identities.email[0];
            var uid = cham;

            return new string[] { "value1", "value2", useremail, uid };
        }
    }
}
