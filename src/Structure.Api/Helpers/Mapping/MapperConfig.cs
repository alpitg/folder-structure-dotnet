
using AutoMapper;

namespace Structure.Api.Helpers.Mapping
{
    public static class MapperConfig
    {
        public static IMapper GetMapperConfigs()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TenantProfile());
                mc.AddProfile(new ActionProfile());
                mc.AddProfile(new PageProfile());
                mc.AddProfile(new RoleProfile());
                mc.AddProfile(new UserProfile());

                // GYMKHANA
                mc.AddProfile(new FacilityProfile());
                mc.AddProfile(new GenderProfile());
                
            });
            return mappingConfig.CreateMapper();
        }
    }
}
