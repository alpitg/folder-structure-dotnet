
namespace Structure.Data
{

    public class Tenant : BaseEntity
    {
        public Guid? Id { get; set; }
        public string? TenancyName { get; set; }
        public string? Name { get; set; }
        public string? ConnectionString { get; set; }
        public string? Edition { get; set; }
        public string? Address { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public bool IsInTrialPeriod { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}
