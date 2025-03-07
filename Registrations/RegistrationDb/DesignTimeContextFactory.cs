using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Registration.Db
{
    internal class DesignTimeContextFactory : IDesignTimeDbContextFactory<RegistrationDbContext>
    {
        public RegistrationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RegistrationDbContext>();
            optionsBuilder.UseSqlite("Data Source=..\\Registration.Api\\registrations.db");

            return new RegistrationDbContext(optionsBuilder.Options);
        }
    }
}
