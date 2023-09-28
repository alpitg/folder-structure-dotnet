using AutoMapper;
using Structure.Data;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Helpers.Mapping
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<Tenant, TenantDto>().ReverseMap();
            CreateMap<AddTenantCommand, Tenant>();
            CreateMap<UpdateTenantCommand, Tenant>();
        }
    }
}
