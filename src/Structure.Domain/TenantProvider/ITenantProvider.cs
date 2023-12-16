
using Structure.Domain.Entities;

namespace Structure.Data
{
    public interface ITenantProvider
    {
        public string GetDatabaseProvider();
        public string GetConnectionString();
        public Tenant GetTenant();
    }
}
