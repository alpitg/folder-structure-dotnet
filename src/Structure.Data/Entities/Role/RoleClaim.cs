using Microsoft.AspNetCore.Identity;
using System;

namespace Structure.Data
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public Guid ActionId { get; set; }
        public virtual Role Role { get; set; }
        public Action Action { get; set; }
    }
}
