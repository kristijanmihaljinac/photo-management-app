using Microsoft.EntityFrameworkCore;
using PhotoManagementApp.Infrastructure.Entities;

namespace PhotoManagementApp.Infrastructure
{
    public class DbContextFactory : IDbContextFactory
    {
        private DbContextOptions<Context> _options;

        public DbContextFactory(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer(connectionString);
            _options = builder.Options;
        }

        public PhotoManagementDbContext Create()
        {
            return new PhotoManagementDbContext(_options);
        }
    }
}
