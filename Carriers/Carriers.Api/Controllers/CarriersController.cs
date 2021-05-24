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
        public async Task<ActionResult<Carrier>> GetByCode(string carrierCode)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[CarriersController:GetByCode] CarrierCode: {carrierCode}");

            // input validation
            if (string.IsNullOrWhiteSpace(carrierCode))
            {
                return BadRequest("CarrierCode cannot be null or empty");
            }

            // service
            var carrier = await _carrierService.GetCarrier(carrierCode);

            // response
            if (carrier == null)
            {
                _logger.LogDebug($"No carrier found for carrier code:{carrierCode}");
                return NotFound(carrierCode);
            }

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"[CarriersController:GetByCode] Carrier: {JsonConvert.SerializeObject(carrier)}");
            }

            return Ok(carrier);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrier>>> GetCarriers()
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[CarriersController:GetCarriers]");

            // service
            var carriers = await _carrierService.GetCarriers();

            // response
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"[CarriersController:GetByCode] Carrier: {JsonConvert.SerializeObject(carriers)}");
            }

            return Ok(carriers);      }

        [HttpDelete]
        [Route("{carrierCode}")]
        public async Task<ActionResult> DeleteCarrier(string carrierCode)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[CarriersController:DeleteCarrier] CarrierCode: {carrierCode}");

            // input validation
            if (string.IsNullOrWhiteSpace(carrierCode))
            {
                return BadRequest("CarrierCode cannot be null or empty");
            }

            // service
            await _carrierService.DeleteCarrier(carrierCode);

            // response
            _logger.LogDebug($"Carrier with carrier code:{carrierCode} deleted");
           
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Carrier>> SaveCarrier([FromBody] Carrier carrier)
        {
            // input validation
            if(carrier == null)
                return BadRequest("Carrier cannot be null");

            if (string.IsNullOrWhiteSpace(carrier.CarrierCode))
                return BadRequest("CarrierCode cannot be null or empty");

            if (string.IsNullOrWhiteSpace(carrier.CarrierName))
                return BadRequest("CarrierName cannot be null or empty");

            _logger.LogDebug($"[CarriersController:SaveCarrier] Carrier: {JsonConvert.SerializeObject(carrier)}");
            
            // service
            await _carrierService.SaveCarrier(carrier);

            // response
            _logger.LogDebug($"Carrier added with carrier id: {carrier.CarrierId}");

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"[CarriersController:SaveCarrier] New Carrier: {JsonConvert.SerializeObject(carrier)}");
            }

            return Ok(carrier);
        }

        [HttpPut]
        [Route("{carrierCode}")]
        public async Task<ActionResult<Carrier>> UpdateCarrier(string carrierCode, [FromBody] Carrier carrier)
        {
            // input validation
            if(carrier == null)
                return BadRequest("Carrier cannot be null");

            // set carrier code from path to carrier object
            carrier.CarrierCode = carrierCode;
            
            if (string.IsNullOrWhiteSpace(carrier.CarrierCode))
                return BadRequest("CarrierCode cannot be null or empty");

            if (string.IsNullOrWhiteSpace(carrier.CarrierName))
                return BadRequest("CarrierName cannot be null or empty");

            _logger.LogDebug($"[CarriersController:UpdateCarrier] Carrier: {JsonConvert.SerializeObject(carrier)}");
            
            // service
            await _carrierService.SaveCarrier(carrier);

            // response
            _logger.LogDebug($"Carrier with carrier code: {carrier.CarrierCode} updated");

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"[CarriersController:UpdateCarrier] Carrier updated : {JsonConvert.SerializeObject(carrier)}");
            }

            return Ok(carrier);
        }
    }
}