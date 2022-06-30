using System;
using System.Collections.Generic;

namespace PhotoManagementApp.Infrastructure.Entities
{
    public partial class PackageRestrictionValue
    {
        public long Id { get; set; }
        public long PackageRestrictionId { get; set; }
        public Guid PackageId { get; set; }
        public string Value { get; set; } = null!;
        public DateTimeOffset DateCreated { get; set; }
        public Guid UserCreatedId { get; set; }
        public DateTimeOffset? DateLastModified { get; set; }
        public Guid? UserLastModifiedId { get; set; }
        public bool Active { get; set; }

        public virtual Package Package { get; set; } = null!;
        public virtual PackageRestriction PackageRestriction { get; set; } = null!;
        public virtual AppUser UserCreated { get; set; } = null!;
        public virtual AppUser? UserLastModified { get; set; }
    }
}
