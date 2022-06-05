using Microsoft.EntityFrameworkCore;
using PhotoManagementApp.Infrastructure.Entities;

namespace PhotoManagementApp.Infrastructure
{
    public class PhotoManagementDbContext : Context
    {
        public PhotoManagementDbContext(DbContextOptions<Context> options) : base(options)
        {

        }

    }
}
