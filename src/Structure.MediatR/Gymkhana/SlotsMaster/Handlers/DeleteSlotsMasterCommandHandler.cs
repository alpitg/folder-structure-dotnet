using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class DeleteSlotsMasterCommandHandler : IRequestHandler<DeleteSlotsMasterCommand, ServiceResponse<SlotsMasterDto>>
    {
        private readonly ISlotsMasterRepository _slotsMasterRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;

        public DeleteSlotsMasterCommandHandler(
           ISlotsMasterRepository SlotsMasterRepository,
            IUnitOfWork<StructureDbContext> uow
            )
        {
            _slotsMasterRepository = SlotsMasterRepository;
            _uow = uow;
        }

        public async Task<ServiceResponse<SlotsMasterDto>> Handle(DeleteSlotsMasterCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _slotsMasterRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                return ServiceResponse<SlotsMasterDto>.Return404();
            }
            _slotsMasterRepository.Delete(request.Id);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<SlotsMasterDto>.Return500();
            }
            return ServiceResponse<SlotsMasterDto>.ReturnSuccess();
        }
    }
}
