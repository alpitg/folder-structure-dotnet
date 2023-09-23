using Microsoft.AspNetCore.Identity;
using System;

namespace Structure.Data
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public virtual User User { get; set; } = null;
    }
}
