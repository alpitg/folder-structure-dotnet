using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class DeleteHolidayCalendarCommandHandler : IRequestHandler<DeleteHolidayCalendarCommand, ServiceResponse<HolidayCalendarDto>>
    {
        private readonly IHolidayCalendarRepository _HolidayCalendarRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;

        public DeleteHolidayCalendarCommandHandler(
           IHolidayCalendarRepository HolidayCalendarRepository,
            IUnitOfWork<StructureDbContext> uow
            )
        {
            _HolidayCalendarRepository = HolidayCalendarRepository;
            _uow = uow;
        }

        public async Task<ServiceResponse<HolidayCalendarDto>> Handle(DeleteHolidayCalendarCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _HolidayCalendarRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                return ServiceResponse<HolidayCalendarDto>.Return404();
            }
            _HolidayCalendarRepository.Delete(request.Id);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<HolidayCalendarDto>.Return500();
            }
            return ServiceResponse<HolidayCalendarDto>.ReturnSuccess();
        }
    }
}
