using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Structure.MediatR.Handlers
{
    public class GetAllHolidayCalendarQueryHandler : IRequestHandler<GetAllHolidayCalendarQuery, List<HolidayCalendarDto>>
    {
        private readonly IHolidayCalendarRepository _HolidayCalendarRepository;
        private readonly IMapper _mapper;

        public GetAllHolidayCalendarQueryHandler(
            IHolidayCalendarRepository HolidayCalendarRepository,
            IMapper mapper)
        {
            _HolidayCalendarRepository = HolidayCalendarRepository;
            _mapper = mapper;

        }
        public async Task<List<HolidayCalendarDto>> Handle(GetAllHolidayCalendarQuery request, CancellationToken cancellationToken)
        {
            var entities = await _HolidayCalendarRepository.All.OrderBy(c => c.EventDate).ToListAsync();
            return _mapper.Map<List<HolidayCalendarDto>>(entities);
        }
    }
}
