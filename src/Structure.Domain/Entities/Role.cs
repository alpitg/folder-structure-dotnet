
using Microsoft.AspNetCore.Identity;

namespace Structure.Domain.Entities;

public partial class Role: IdentityRole
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime ModifiedDate { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public bool IsSuperRole { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? DeletedByNavigation { get; set; }

    public virtual User ModifiedByNavigation { get; set; } = null!;

    public virtual ICollection<RoleClaim> RoleClaims { get; set; } = new List<RoleClaim>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
