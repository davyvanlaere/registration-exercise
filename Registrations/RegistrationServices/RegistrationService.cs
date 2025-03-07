
using Microsoft.EntityFrameworkCore;
using Registration.Db;
using Registration.Db.Model;

namespace Registration.Services
{
    public class RegistrationService : Registrations.Interfaces.IRegistrationService
    {
        private readonly RegistrationDbContext _dbContext;

        public RegistrationService(RegistrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Registration.Db.Model.Registration>> GetRegistrationsAsync()
        {
            return await _dbContext.Registrations.Include(r => r.SocialSkills).Include(r => r.SocialMediaAddresses).ToListAsync();
        }

        public async Task<Registration.Db.Model.Registration?> GetRegistrationAsync(int id)
        {
            return await _dbContext.Registrations.Include(r => r.SocialSkills).Include(r => r.SocialMediaAddresses)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<int> CreateRegistrationAsync(Registration.Db.Model.Registration registration)
        {
            _dbContext.Registrations.Add(registration);
            await _dbContext.SaveChangesAsync();
            return registration.Id;
        }

        public async Task<List<SocialMediaPlatform>> GetSocialMediaPlatformsAsync()
        {
            return await _dbContext.SocialMediaPlatforms.ToListAsync();
        }
    }
}
