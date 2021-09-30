using Microsoft.AspNetCore.Mvc;
using jarowa.Api.Phone;

namespace jarowa.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PhoneController : ControllerBase
    {

        private readonly ILogger<PhoneController> _logger;

        public PhoneController(ILogger<PhoneController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Validate(string phoneNumber, string defaultCountryCode)
        {
            return new PhoneNumber().Validate(phoneNumber, defaultCountryCode);
        }

    }
}