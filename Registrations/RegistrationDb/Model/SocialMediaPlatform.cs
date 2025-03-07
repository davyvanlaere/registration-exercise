using System.ComponentModel.DataAnnotations;

namespace Registration.Db.Model
{
    public class SocialMediaPlatform
    {
        [Key]
        public string Id { get; set; } // Platform name (LinkedIn, Facebook, etc.)
        public string ValidationRegex { get; set; }
    }
}
