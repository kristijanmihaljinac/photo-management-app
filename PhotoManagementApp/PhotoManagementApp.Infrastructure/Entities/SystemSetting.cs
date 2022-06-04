using System;
using System.Collections.Generic;

namespace PhotoManagementApp.Infrastructure.Entities
{
    public partial class SystemSetting
    {
        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
