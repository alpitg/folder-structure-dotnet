using AutoMapper;
using Structure.Data;
using Structure.Data.Dto;
using Structure.MediatR.Commands;

namespace Structure.Api.Helpers.Mapping
{
    public class HolidayCalenderProfile : Profile
    {

        public HolidayCalenderProfile() { 
        CreateMap<HolidayCalenders,  HolidayCalenderDto>().ReverseMap();
            CreateMap<AddHolidayCalenderCommands, HolidayCalenders>();
            CreateMap<GetAllHolidayCalenderCommands, HolidayCalenders>();
        }

    }
}
