using System;
using System.Collections.Generic;

namespace PhotoManagementApp.Infrastructure.Entities
{
    public partial class AppUser
    {
        public AppUser()
        {
            PackageRestrictionUserCreateds = new HashSet<PackageRestriction>();
            PackageRestrictionUserLastModifieds = new HashSet<PackageRestriction>();
            PackageRestrictionValueUserCreateds = new HashSet<PackageRestrictionValue>();
            PackageRestrictionValueUserLastModifieds = new HashSet<PackageRestrictionValue>();
            PackageUserCreateds = new HashSet<Package>();
            PackageUserLastModifieds = new HashSet<Package>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<PackageRestriction> PackageRestrictionUserCreateds { get; set; }
        public virtual ICollection<PackageRestriction> PackageRestrictionUserLastModifieds { get; set; }
        public virtual ICollection<PackageRestrictionValue> PackageRestrictionValueUserCreateds { get; set; }
        public virtual ICollection<PackageRestrictionValue> PackageRestrictionValueUserLastModifieds { get; set; }
        public virtual ICollection<Package> PackageUserCreateds { get; set; }
        public virtual ICollection<Package> PackageUserLastModifieds { get; set; }
    }
}
