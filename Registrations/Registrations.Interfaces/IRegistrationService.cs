using Registration.Db.Model;

namespace Registrations.Interfaces
{
    // i normally would not put EF model classes on an interface, but would use contract classes and automap them
    public interface IRegistrationService
    {
        Task<List<Registration.Db.Model.Registration>> GetRegistrationsAsync();
        Task<Registration.Db.Model.Registration> GetRegistrationAsync(int id);
        Task<int> CreateRegistrationAsync(Registration.Db.Model.Registration registration);
        Task<List<SocialMediaPlatform>> GetSocialMediaPlatformsAsync();
    }
}
