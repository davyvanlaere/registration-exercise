namespace Registration.Api.Model
{
    public class CreateRegistrationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> SocialSkills { get; set; }
        public List<SocialMediaAddress> SocialMediaAddresses { get; set; }
    }

    public class SocialMediaAddress
    {
        public string PlatformId { get; set; }
        public string Address { get; set; }
    }

}
