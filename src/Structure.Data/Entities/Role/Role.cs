using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Structure.Data
{
    public class Role : IdentityRole<Guid>, IMustHaveTenant
    {
        public Guid? TenantId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public Users? CreatedByUser { get; set; }
        [ForeignKey("ModifiedBy")]
        public Users? ModifiedByUser { get; set; }
        [ForeignKey("DeletedBy")]
        public Users? DeletedByUser { get; set; }
        public bool IsSuperRole { get; set; } = false;
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
