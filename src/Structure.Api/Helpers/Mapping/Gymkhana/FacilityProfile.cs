using AutoMapper;
using Structure.Data.Dto;
using Structure.Data;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Helpers.Mapping
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
            CreateMap<Facility, FacilityDto>().ReverseMap();
            CreateMap<AddFacilityCommand, Facility>();
            CreateMap<UpdateFacilityCommand, Facility>();
        }
    }
}
