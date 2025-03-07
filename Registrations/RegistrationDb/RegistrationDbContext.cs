using Microsoft.EntityFrameworkCore;
using Registration.Db.Model;

namespace Registration.Db
{
    public class RegistrationDbContext : DbContext
    {
        public DbSet<Model.Registration> Registrations { get; set; }
        public DbSet<SocialSkill> SocialSkills { get; set; }
        public DbSet<SocialMediaAddress> SocialMediaAddresses { get; set; }
        public DbSet<SocialMediaPlatform> SocialMediaPlatforms { get; set; }

        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SocialMediaAddress>().HasKey(sma => new { sma.RegistrationId, sma.PlatformId });

            modelBuilder.Entity<SocialMediaPlatform>().HasData(new SocialMediaPlatform
            {
                Id = "linkedin",
                ValidationRegex = "linkedin"
            },
            new SocialMediaPlatform
            {
                Id = "instagram",
                ValidationRegex = "instagram"
            },
            new SocialMediaPlatform
            {
                Id = "facebook",
                ValidationRegex = "facebook"
            });
        }
    }
}
