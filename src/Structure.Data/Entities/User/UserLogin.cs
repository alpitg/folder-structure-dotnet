using Microsoft.AspNetCore.Identity;
using System;

namespace Structure.Data
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public virtual Users User { get; set; }
    }
}
