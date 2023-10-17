
namespace Structure.Data.Dto
{
    public class TenantDto
    {
        public Guid Id { get; set; }
        public string? TenancyName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }        
        public string? Password { get; set; }
        public string? Edition { get; set; }
        public string? Address { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public bool IsInTrialPeriod { get; set; }
        public bool ShouldChangePasswordOnNextLogin { get; set; }
        public bool IsActive { get; set; }
    }
}
