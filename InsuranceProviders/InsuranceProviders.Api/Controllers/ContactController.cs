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
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        //static readonly string[] scopeRequiredByApi = new string[] {"access_as_user"};

        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpGet]
        [Route("InsuranceProviderCode}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetByInsuranceProviderCode(string insuranceProviderCode)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[ContactController:GetContacts]");

            var contacts = await _contactService.GetContacts(insuranceProviderCode);
            
            // response
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"[ContactController:GetContacts] Contact: {JsonConvert.SerializeObject(contacts)}");
            }

            return Ok(contacts);
        }

        [HttpGet]
        //[Route("{contactId}")]
        public async Task<ActionResult<Contact>> GetContact(int contactId)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[InsuranceProvidersController:GetInsuranceProviders]");
            // input validation
            if (contactId==0)
            {
                return BadRequest("Contact cannot be null or empty");
            }

            return await _contactService.GetContact(contactId);
        }

        [HttpDelete]
        [Route("{ContactId}")]
        public async Task<int> DeleteContact(int ContactId)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[ContactController:DeleteContact] ContactId: {ContactId}");

            // input validation
           
            // service
          return  await _contactService.DeleteContact(ContactId);

          
        }

        [HttpPost]
        [Route("{jsonContact}")]
        public async Task<int> SaveContact(string jsonContact)
        {

            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            return await _contactService.SaveContact(JsonConvert.DeserializeObject<Contact>(jsonContact));
        }

        [HttpPut]
        [Route("{jsonContact}")]
        public async Task<int> UpdateContact(string jsonContact)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            return await _contactService.UpdateContact(JsonConvert.DeserializeObject<Contact>(jsonContact));
        }
    }

}

