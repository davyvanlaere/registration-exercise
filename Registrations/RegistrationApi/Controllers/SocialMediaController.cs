using Microsoft.AspNetCore.Mvc;
using Registrations.Interfaces;

namespace Registration.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SocialMediaController : ControllerBase
    {
        private readonly IRegistrationService _service;

        public SocialMediaController(IRegistrationService service, ILogger<RegistrationController> logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrations()
        {
            var platforms = await _service.GetSocialMediaPlatformsAsync();
            return Ok(platforms);
        }

    }
}
