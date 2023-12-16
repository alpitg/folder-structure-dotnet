using System;
using System.Collections.Generic;

namespace Structure.Domain.Entities;

public partial class Action
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Order { get; set; }

    public Guid PageId { get; set; }

    public string Code { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime ModifiedDate { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? TenantId { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Page Page { get; set; } = null!;

    public virtual ICollection<RoleClaim> RoleClaims { get; set; } = new List<RoleClaim>();

    public virtual ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();
}
