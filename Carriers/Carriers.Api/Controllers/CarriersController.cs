using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carriers.Domain.Models;
using Carriers.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using Newtonsoft.Json;

namespace Carriers.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CarriersController : ControllerBase
    {
        private readonly ILogger<CarriersController> _logger;
        private readonly ICarrierService _carrierService;

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        //static readonly string[] scopeRequiredByApi = new string[] {"access_as_user"};

        public CarriersController(ICarrierService carrierService, ILogger<CarriersController> logger)
        {
            _logger = logger;
            _carrierService = carrierService;
        }

        [HttpGet]
        [Route("{carrierCode}")]
        public async Task<Carrier> GetByCode(string carrierCode)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            return await _carrierService.GetCarrier(carrierCode);
        }
        [HttpGet]
        public async Task<IEnumerable<Carrier>> GetCarriers()
        {
            return await _carrierService.GetCarriers();
        }

        [HttpDelete]
        [Route("{carrierCode}")]
        public async Task<int> DeleteCarrier(string carrierCode)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            return await _carrierService.DeleteCarrier(carrierCode);
        }

        [HttpPost]
        [Route("{jsonCarrier}")]
        public async Task<int> SaveCarrier(string jsonCarrier)
        {

            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            return await _carrierService.SaveCarrier(JsonConvert.DeserializeObject<Carrier>(jsonCarrier));
        }

        [HttpPut]
        [Route("{jsonCarrier}")]
        public async Task<int> UpdateCarrier(string jsonCarrier)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            return await _carrierService.UpdateCarrier(JsonConvert.DeserializeObject<Carrier>(jsonCarrier));
        }
    }
}