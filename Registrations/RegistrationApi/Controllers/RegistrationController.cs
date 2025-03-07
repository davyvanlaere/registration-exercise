using Microsoft.AspNetCore.Mvc;
using Registration.Api.Model;
using Registration.Db.Model;
using Registrations.Interfaces;

namespace Registration.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;

        public RegistrationController(IRegistrationService service, ILogger<RegistrationController> logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrations()
        {
            var registrations = await _service.GetRegistrationsAsync();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistration(int id)
        {
            var registration = await _service.GetRegistrationAsync(id);
            if (registration == null) return NotFound();
            return Ok(registration);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistration(CreateRegistrationRequest registration)
        {
            var id = await _service.CreateRegistrationAsync(new Db.Model.Registration 
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                SocialSkills = registration.SocialSkills == null 
                    ? new List<SocialSkill>() 
                    : registration.SocialSkills.Select(skill => new SocialSkill 
                    {
                        Skill = skill
                    }).ToList(),
                SocialMediaAddresses = registration.SocialMediaAddresses == null 
                    ? new List<Db.Model.SocialMediaAddress>()
                    : registration.SocialMediaAddresses.Select(i => new Db.Model.SocialMediaAddress 
                    {
                        Address = i.Address,
                        PlatformId = i.PlatformId
                    }).ToList()
            });
            return Ok(new { id });
        }
    }
}
