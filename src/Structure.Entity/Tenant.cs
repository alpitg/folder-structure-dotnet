using System;
using System.Collections.Generic;

namespace Structure.Entity
{
    public partial class Tenant
    {
        public Tenant()
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string? TenancyName { get; set; }
        public string Name { get; set; } = null!;
        public string? ConnectionString { get; set; }
        public string? Edition { get; set; }
        public string? Address { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public bool IsInTrialPeriod { get; set; }
        public bool IsActive { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
