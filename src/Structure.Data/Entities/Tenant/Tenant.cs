
using System.ComponentModel.DataAnnotations.Schema;

namespace Structure.Data
{

    public class Tenant
    {
        public Tenant()
        {
            Users = new List<User>();
        }

        public Guid? Id { get; set; }
        public string? TenancyName { get; set; }
        public string? Name { get; set; }
        public string? ConnectionString { get; set; }
        public string? Edition { get; set; }
        public string? Address { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public bool IsInTrialPeriod { get; set; }
        public bool IsActive { get; set; }
        private DateTime _modifiedDate;
        public DateTime ModifiedDate
        {
            get => _modifiedDate;
            set => _modifiedDate = value;
        }
        public Guid ModifiedBy { get; set; }
        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value;
        }
        public Guid CreatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<User> Users { get; set; }
    }
}
