using AutoMapper;
using Structure.Data;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.MediatR.Commands;

namespace Structure.Api.Helpers.Mapping
{
    public class FacilityProfile : Profile
    {

        public FacilityProfile() { 
            CreateMap<FacilitiesCourts, FacilityCourtsDto>().ReverseMap();
            CreateMap<AddFacilityCourtsCommands, FacilitiesCourts>();
            CreateMap<GetFacilityCourtCommand, FacilitiesCourts>();
            CreateMap<GetAllFacilityCourtCommand, FacilitiesCourts>();
            CreateMap<UpdateFacilityCourtCommand, FacilitiesCourts>();
            CreateMap<DeleteFacilityCourtCommand, FacilitiesCourts>();
            CreateMap<Facility, FacilityDto>().ReverseMap();
            CreateMap<AddFacilityCommand, Facility>();
            CreateMap<GetFacilityCommand, Facility>();
            CreateMap<GetAllFacilityCommand, Facility>();
            CreateMap<UpdateFacilityCommand, Facility>();
            CreateMap<DeleteFacilityCommand, Facility>();
        }

    }
}
