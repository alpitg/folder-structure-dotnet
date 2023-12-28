using AutoMapper;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Structure.Helper;
using Structure.Repository.UnitOfWork;
using Structure.Data;
using Structure.Repository;

namespace Structure.MediatR.Handlers
{
    public class AddHolidayCalendarCommandHandler : IRequestHandler<AddHolidayCalendarCommand, ServiceResponse<HolidayCalendarDto>>
    {
        private readonly IHolidayCalendarRepository _HolidayCalendarRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddHolidayCalendarCommandHandler> _logger;
        
        public AddHolidayCalendarCommandHandler(
           IHolidayCalendarRepository HolidayCalendarRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddHolidayCalendarCommandHandler> logger
            )
        {
            _HolidayCalendarRepository = HolidayCalendarRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<HolidayCalendarDto>> Handle(AddHolidayCalendarCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _HolidayCalendarRepository.FindBy(c => c.EventDate == request.EventDate && c.StartTime == request.StartTime && c.EndTime ==  request.EndTime).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Holiday Calendar Already Exist");
                return ServiceResponse<HolidayCalendarDto>.Return409("HolidayCalendar Already Exist.");
            }

            var entity = _mapper.Map<HolidayCalendar>(request);
            entity.Id = Guid.NewGuid();
            _HolidayCalendarRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {
                _logger.LogError("Save Holiday Calendar have Error");
                return ServiceResponse<HolidayCalendarDto>.Return500();
            }
            return ServiceResponse<HolidayCalendarDto>.ReturnResultWith200(_mapper.Map<HolidayCalendarDto>(entity));
        }
    }
}
