using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Structure.Data.Services;
using Structure.Repository;
using Structure.Repository.UnitOfWork;

namespace Structure.Infrastructure.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjectionExt(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<IPropertyMappingService, PropertyMappingService>();
            services.AddTransient<ITenantService, TenantService>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IActionRepository, ActionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserClaimRepository, UserClaimRepository>();
            services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
            services.AddScoped<ILoginAuditRepository, LoginAuditRepository>();
            services.AddScoped<IFacilityCourtRepository, FacilityCourtRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IFacilityTypeRepository, FacilityTypeRepository>();




        }
    }
}
