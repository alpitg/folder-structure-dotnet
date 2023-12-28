using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Microsoft.Extensions.Logging;

namespace Structure.MediatR.Handlers
{
    public class GetHolidayCalendarQueryHandler : IRequestHandler<GetHolidayCalendarQuery, ServiceResponse<HolidayCalendarDto>>
    {
        private readonly IHolidayCalendarRepository _HolidayCalendarRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetHolidayCalendarQueryHandler> _logger;

        public GetHolidayCalendarQueryHandler(
            IHolidayCalendarRepository HolidayCalendarRepository,
            IMapper mapper,
            ILogger<GetHolidayCalendarQueryHandler> logger)
        {
            _HolidayCalendarRepository = HolidayCalendarRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ServiceResponse<HolidayCalendarDto>> Handle(GetHolidayCalendarQuery request, CancellationToken cancellationToken)
        {
            var entity = await _HolidayCalendarRepository.FindAsync(request.Id);
            if (entity != null)
                return ServiceResponse<HolidayCalendarDto>.ReturnResultWith200(_mapper.Map<HolidayCalendarDto>(entity));
            else
            {
                _logger.LogError("Not found");
                return ServiceResponse<HolidayCalendarDto>.Return404();
            }
        }
    }
}
