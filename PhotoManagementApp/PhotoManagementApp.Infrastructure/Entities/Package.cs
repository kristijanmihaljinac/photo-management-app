using System;
using System.Collections.Generic;

namespace PhotoManagementApp.Infrastructure.Entities
{
    public partial class Package
    {
        public Package()
        {
            PackageRestrictionValues = new HashSet<PackageRestrictionValue>();
        }

        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTimeOffset DateCreated { get; set; }
        public Guid UserCreatedId { get; set; }
        public DateTimeOffset? DateLastModified { get; set; }
        public Guid? UserLastModifiedId { get; set; }
        public bool Active { get; set; }

        public virtual AppUser UserCreated { get; set; } = null!;
        public virtual AppUser? UserLastModified { get; set; }
        public virtual ICollection<PackageRestrictionValue> PackageRestrictionValues { get; set; }
    }
}
