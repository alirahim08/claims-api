using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carriers.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;

namespace Carriers.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CarriersController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CarriersController> _logger;

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] {"access_as_user"};

        public CarriersController(ILogger<CarriersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public CarrierCollection Get()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

            var rng = new Random();
            return null;
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //     {
            //         Date = DateTime.Now.AddDays(index),
            //         TemperatureC = rng.Next(-20, 55),
            //         Summary = Summaries[rng.Next(Summaries.Length)]
            //     })
            //     .ToArray();
        }
    }
}