using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carriers.Domain.Models;

namespace Carriers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarriersController : ControllerBase
    {
       
        private readonly ILogger<CarriersController> _logger;

        public CarriersController(ILogger<CarriersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Carrier> Get()
        {
            return new List<Carrier>();
        }
    }
}
