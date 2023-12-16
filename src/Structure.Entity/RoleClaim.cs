using System;
using System.Collections.Generic;

namespace Structure.Entity
{
    public partial class RoleClaim
    {
        public int Id { get; set; }
        public Guid ActionId { get; set; }
        public Guid RoleId { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }

        public virtual Action Action { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
