using AutoMapper;
using Structure.Data;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Helpers.Mapping
{
    public class FacilityTypeProfile : Profile
    {

        public FacilityTypeProfile()
        {
            CreateMap<FacilityTypes, FacilityTypeProfile>().ReverseMap();
            CreateMap<AddFacilityTypeCommand, FacilityTypes>();
            CreateMap<GetFacilityTypeQuery, FacilityTypes>();
            CreateMap<GetAllFacilityTypeQuery, FacilityTypes>();
            CreateMap<UpdateFacilityTypeCommand, FacilityTypes>();
            CreateMap<DeleteFacilityTypeCommand, FacilityTypes>();

        }

    }
}
