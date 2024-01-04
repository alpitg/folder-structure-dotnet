using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Structure.Data.Dto;

namespace Structure.Data
{
    public class TenantProvider : ITenantProvider
    {
        private readonly TenantSettings _tenantSettings = new TenantSettings();
        private HttpContext _httpContext;
        private Tenant _currentTenant;

        public TenantProvider(IOptions<TenantSettings> tenantSettings, IHttpContextAccessor contextAccessor)
        {
            _tenantSettings = tenantSettings.Value;
            _httpContext = contextAccessor.HttpContext;
            if (_httpContext != null)
            {
                _httpContext.Request.Headers.TryGetValue("TenantId", out var tenantId);
                if (!string.IsNullOrEmpty(tenantId))
                {
                    SetTenant(new Guid(tenantId));
                }
                else
                {
                    SetTenant(null);
                }
            }
        }
        private void SetTenant(Guid? tenantId)
        {
            _currentTenant = _tenantSettings.Tenants.FirstOrDefault(a => a.Id == tenantId) ?? new Tenant();
            if (!tenantId.HasValue || _currentTenant == null || string.IsNullOrEmpty(_currentTenant.ConnectionString))
            {
                SetDefaultConnectionStringToCurrentTenant();
            }
        }
        private void SetDefaultConnectionStringToCurrentTenant()
        {
            _currentTenant.ConnectionString = _tenantSettings.Defaults?.ConnectionString;
        }
        public string GetConnectionString()
        {
            return _currentTenant?.ConnectionString ?? "";
        }
        public string GetDatabaseProvider()
        {
            return _tenantSettings.Defaults?.DBProvider ?? "";
        }
        public Tenant GetTenant()
        {
            return _currentTenant;
        }
    }
}
