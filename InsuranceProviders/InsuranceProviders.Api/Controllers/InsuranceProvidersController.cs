using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceProviders.Domain.Models;
using InsuranceProviders.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using Newtonsoft.Json;

namespace InsuranceProviders.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InsuranceProvidersController : ControllerBase
    {
        private readonly ILogger<InsuranceProvidersController> _logger;
        private readonly IInsuranceProviderService _insuranceProviderService;

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        //static readonly string[] scopeRequiredByApi = new string[] {"access_as_user"};

        public InsuranceProvidersController(IInsuranceProviderService insuranceProviderService, ILogger<InsuranceProvidersController> logger)
        {
            _logger = logger;
            _insuranceProviderService = insuranceProviderService;
        }

        [HttpGet]
        [Route("{insuranceProviderCode}")]
        public async Task<ActionResult<Domain.Models.InsuranceProvider>> GetByCode(string insuranceProviderCode)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[InsuranceProvidersController:GetByCode] InsuranceProviderCode: {insuranceProviderCode}");

            // input validation
            if (string.IsNullOrWhiteSpace(insuranceProviderCode))
            {
                return BadRequest("InsuranceProviderCode cannot be null or empty");
            }

            // service
            var insuranceProvider = await _insuranceProviderService.GetInsuranceProvider(insuranceProviderCode);

            // response
            if (insuranceProvider == null)
            {
                _logger.LogDebug($"No Insurance Provider found for insurance code:{insuranceProviderCode}");
                return NotFound(insuranceProviderCode);
            }

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"[InsuranceProvidersController:GetByCode] InsuranceProvider: {JsonConvert.SerializeObject(insuranceProvider)}");
            }

            return Ok(insuranceProvider);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Models.InsuranceProvider>>> GetInsuranceProviders()
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[InsuranceProvidersController:GetInsuranceProviders]");

            // service
            var InsuranceProviders = await _insuranceProviderService.GetInsuranceProviders();

            // response
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"[InsuranceProvidersController:GetByCode] InsuranceProvider: {JsonConvert.SerializeObject(InsuranceProviders)}");
            }

            return Ok(InsuranceProviders);      }

        [HttpDelete]
        [Route("{insuranceProviderCode}")]
        public async Task<ActionResult> DeleteInsuranceProvider(string insuranceProviderCode)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[InsuranceProvidersController:Deleteinsuranceprovider] insuranceProviderCode: {insuranceProviderCode}");

            // input validation
            if (string.IsNullOrWhiteSpace(insuranceProviderCode))
            {
                return BadRequest("InsuranceProviderCode cannot be null or empty");
            }

            // service
            await _insuranceProviderService.DeleteInsuranceProvider(insuranceProviderCode);

            // response
            _logger.LogDebug($"InsuranceProvider with InsuranceProvider code:{insuranceProviderCode} deleted");
           
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<InsuranceProvider>> Saveinsuranceprovider([FromBody] InsuranceProvider insuranceProvider)
        {
            // input validation
            if(insuranceProvider == null)
                return BadRequest("InsuranceProvider cannot be null");

            if (string.IsNullOrWhiteSpace(insuranceProvider.InsuranceCode))
                return BadRequest("InsuranceProviderCode cannot be null or empty");

            if (string.IsNullOrWhiteSpace(insuranceProvider.InsuranceName))
                return BadRequest("InsuranceProviderName cannot be null or empty");

            _logger.LogDebug($"[InsuranceProvidersController:SaveInsuranceprovider] insuranceProvider: {JsonConvert.SerializeObject(insuranceProvider)}");
            
            // service
            await _insuranceProviderService.SaveInsuranceProvider(insuranceProvider);

            // response
            _logger.LogDebug($"insuranceprovider added with insuranceprovider id: {insuranceProvider.InsuranceId}");

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"[InsuranceProvidersController:Saveinsuranceprovider] New insuranceProvider: {JsonConvert.SerializeObject(insuranceProvider)}");
            }

            return Ok(insuranceProvider);
        }

        [HttpPut]
        [Route("{insuranceProviderCode}")]
        public async Task<ActionResult<InsuranceProvider>> Updateinsuranceprovider(string insuranceProviderCode, [FromBody] InsuranceProvider insuranceProvider)
        {
            // input validation
            if(insuranceProvider == null)
                return BadRequest("InsuranceProvider cannot be null");

            // set insuranceprovider code from path to insuranceprovider object
            insuranceProvider.InsuranceCode = insuranceProviderCode;
            
            if (string.IsNullOrWhiteSpace(insuranceProvider.InsuranceCode))
                return BadRequest("insuranceProvider Code cannot be null or empty");

            if (string.IsNullOrWhiteSpace(insuranceProvider.InsuranceName))
                return BadRequest("InsuranceProvider Name cannot be null or empty");

            _logger.LogDebug($"[InsuranceProvidersController:Updateinsuranceprovider] insuranceProvider: {JsonConvert.SerializeObject(insuranceProvider)}");
            
            // service
            await _insuranceProviderService.UpdateInsuranceProvider(insuranceProvider);

            // response
            _logger.LogDebug($"InsuranceProvider with InsuranceProvider code: {insuranceProvider.InsuranceCode} updated");

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"[InsuranceProvidersController:UpdateInsuranceProvider] InsuranceProvider updated : {JsonConvert.SerializeObject(insuranceProvider)}");
            }

            return Ok(insuranceProvider);
        }
    }
}