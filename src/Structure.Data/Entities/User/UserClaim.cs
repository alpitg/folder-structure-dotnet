using Microsoft.AspNetCore.Identity;
using System;

namespace Structure.Data
{
    public class UserClaim : IdentityUserClaim<Guid>
    {
        public Guid ActionId { get; set; }
        public virtual Users? User { get; set; }
        public Action? Action { get; set; }
    }
}
