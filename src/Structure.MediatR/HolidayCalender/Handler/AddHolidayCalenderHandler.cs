
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handler
{
    public class AddHolidayCalenderHandler : IRequestHandler<AddHolidayCalenderCommands, ServiceResponse<HolidayCalenderDto>>
    {

        private readonly IHolidayCalenderRepository _holidayCalenderRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddHolidayCalenderHandler> _logger;


        public AddHolidayCalenderHandler(
            IHolidayCalenderRepository holidayCalenderRepository,
            IUnitOfWork<StructureDbContext> uow,
            IMapper mapper,
            ILogger<AddHolidayCalenderHandler> logger
            )
        {
            _holidayCalenderRepository = holidayCalenderRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }


        public async Task<ServiceResponse<HolidayCalenderDto>> Handle(AddHolidayCalenderCommands request, CancellationToken cancellationToken)
        {
            var data = new List<HolidayCalenders>();
            if (request != null)
            {
                var holiday = new HolidayCalenders()
                {
                    Id = request.Id,
                    EventDate = request.EventDate,
                    IsForAllDay = request.IsForAllDay,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    EventName = request.EventName,
                };
                data.Add(holiday);
            }

            var entity = _mapper.Map<HolidayCalenders>(data.FirstOrDefault());
            entity.Id = Guid.NewGuid();
            _holidayCalenderRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {
                _logger.LogError("Save Have error");
                return ServiceResponse<HolidayCalenderDto>.Return500();
            }
            return ServiceResponse<HolidayCalenderDto>.ReturnResultWith200(_mapper.Map<HolidayCalenderDto>(entity));

        }

    }
}
