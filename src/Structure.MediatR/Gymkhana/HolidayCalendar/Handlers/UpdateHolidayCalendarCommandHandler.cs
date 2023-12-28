using AutoMapper;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Helper;
using Microsoft.Extensions.Logging;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class UpdateHolidayCalendarCommandHandler : IRequestHandler<UpdateHolidayCalendarCommand, ServiceResponse<HolidayCalendarDto>>
    {
        private readonly IHolidayCalendarRepository _HolidayCalendarRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateHolidayCalendarCommandHandler> _logger;

        public UpdateHolidayCalendarCommandHandler(
           IHolidayCalendarRepository HolidayCalendarRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<UpdateHolidayCalendarCommandHandler> logger
            )
        {
            _HolidayCalendarRepository = HolidayCalendarRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<HolidayCalendarDto>> Handle(UpdateHolidayCalendarCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _HolidayCalendarRepository.FindBy(c => c.EventDate == request.EventDate && c.StartTime == request.StartTime && c.EndTime ==  request.EndTime).FirstOrDefaultAsync();
           
            if (entityExist != null)
            {
                _logger.LogError("HolidayCalendar Name Already Exist.");
                return ServiceResponse<HolidayCalendarDto>.Return409("HolidayCalendar Name Already Exist.");
            }
            entityExist = await _HolidayCalendarRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            entityExist.EventName = request.EventName;
            entityExist.EventDate = request.EventDate;
            entityExist.StartTime = request.StartTime;
            entityExist.EndTime = request.EndTime;
            entityExist.IsForAllDay = request.IsForAllDay;

            _HolidayCalendarRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<HolidayCalendarDto>.Return500();
            }
            return ServiceResponse<HolidayCalendarDto>.ReturnResultWith200(_mapper.Map<HolidayCalendarDto>(entityExist));
        }
    }
}
