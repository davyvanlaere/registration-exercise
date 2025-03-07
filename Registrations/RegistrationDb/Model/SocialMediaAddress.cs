using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Db.Model
{
    public class SocialMediaAddress
    {
        public int RegistrationId { get; set; }
        public string PlatformId { get; set; }
        public string Address { get; set; }

        [ForeignKey("PlatformId")]
        public SocialMediaPlatform Platform { get; set; }
    }
}
