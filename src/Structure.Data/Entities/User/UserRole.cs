using Microsoft.AspNetCore.Identity;

namespace Structure.Data
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public virtual Users User { get; set; }
        public virtual Role Role { get; set; }
    }
}
