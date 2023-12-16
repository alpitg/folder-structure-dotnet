using Structure.Domain.Entities;

namespace Structure.Data.Dto
{
    public class TenantSettings
    {
        public Configuration? Defaults { get; set; }
        public List<Tenant>? Tenants { get; set; }
    }

    public class Configuration
    {
        public string? DBProvider { get; set; }
        public string? ConnectionString { get; set; }
    }
}
