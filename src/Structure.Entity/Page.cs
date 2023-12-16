using System;
using System.Collections.Generic;

namespace Structure.Entity
{
    public partial class Page
    {
        public Page()
        {
            Actions = new HashSet<Action>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? TenantId { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<Action> Actions { get; set; }
    }
}
