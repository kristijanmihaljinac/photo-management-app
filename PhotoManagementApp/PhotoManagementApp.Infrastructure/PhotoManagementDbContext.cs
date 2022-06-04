using Microsoft.EntityFrameworkCore;
using PhotoManagementApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementApp.Infrastructure
{
    public class PhotoManagementDbContext : Context
    {
        public PhotoManagementDbContext(DbContextOptions<Context> options) : base(options)
        {

        }

         
    }
}
