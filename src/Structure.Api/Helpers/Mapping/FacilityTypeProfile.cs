using AutoMapper;
using Structure.Data;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.MediatR.Commands;

namespace Structure.Api.Helpers.Mapping
{
    public class FacilityTypeProfile : Profile
    {

        public FacilityTypeProfile() {
            CreateMap<FacilityType, FacilityTypeDto>().ReverseMap();
            CreateMap<GetAllFacilityTypeQuery, FacilityType>();
            CreateMap<GetFacilityTypeQuery, FacilityType>();
            CreateMap<AddFacilityTypeCommands, FacilityType>();
            CreateMap<UpdateFacilityTypeCommands, FacilityType>();
            CreateMap<DeleteFacilityTypeCommands, FacilityType>();
        }

    }
}
