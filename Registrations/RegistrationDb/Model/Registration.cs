namespace Registration.Db.Model
{
    public class Registration
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SocialSkill> SocialSkills { get; set; } = new();
        public List<SocialMediaAddress> SocialMediaAddresses { get; set; } = new();
    }
}
