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
        [Route("{carrierCode}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetByCarrierCode(string carrierCode)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogDebug($"[ContactController:GetContacts]");

            var contacts = await _contactService.GetContacts(carrierCode);
            
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
            _logger.LogDebug($"[CarriersController:GetCarriers]");
            // input validation
            if (contactId==0)
            {
                return BadRequest("Contact cannot be null or empty");
            }

            return await _contactService.GetContact(contactId);
        }
    }
}
