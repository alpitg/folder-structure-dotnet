using AutoMapper;
using Structure.Data.Dto;
using Structure.Data;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Helpers.Mapping
{
    public class HolidayCalendarProfile : Profile
    {
        public HolidayCalendarProfile()
        {
            CreateMap<HolidayCalendar, HolidayCalendarDto>().ReverseMap();
            CreateMap<AddHolidayCalendarCommand, HolidayCalendar>();
            CreateMap<UpdateHolidayCalendarCommand, HolidayCalendar>();
        }
    }
}
