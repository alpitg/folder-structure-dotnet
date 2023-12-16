using System;
using System.Collections.Generic;

namespace Structure.Entity
{
    public partial class User
    {
        public User()
        {
            Actions = new HashSet<Action>();
            Pages = new HashSet<Page>();
            RoleCreatedByNavigations = new HashSet<Role>();
            RoleDeletedByNavigations = new HashSet<Role>();
            RoleModifiedByNavigations = new HashSet<Role>();
            UserClaims = new HashSet<UserClaim>();
            UserLogins = new HashSet<UserLogin>();
            UserTokens = new HashSet<UserToken>();
            Roles = new HashSet<Role>();
        }

        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? Provider { get; set; }
        public string? Address { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool ShouldChangePasswordOnNextLogin { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual Tenant? Tenant { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Role> RoleCreatedByNavigations { get; set; }
        public virtual ICollection<Role> RoleDeletedByNavigations { get; set; }
        public virtual ICollection<Role> RoleModifiedByNavigations { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
