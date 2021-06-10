using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceProviders.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;

namespace InsuranceProviders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthcheckController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "InsuranceProviders API Healthcheck";
        }
    }
}