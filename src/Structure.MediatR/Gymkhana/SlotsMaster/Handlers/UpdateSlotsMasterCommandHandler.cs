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
    public class UpdateSlotsMasterCommandHandler : IRequestHandler<UpdateSlotsMasterCommand, ServiceResponse<SlotsMasterDto>>
    {
        private readonly ISlotsMasterRepository _slotsMasterRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSlotsMasterCommandHandler> _logger;

        public UpdateSlotsMasterCommandHandler(
           ISlotsMasterRepository slotsMasterRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<UpdateSlotsMasterCommandHandler> logger
            )
        {
            _slotsMasterRepository = slotsMasterRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<SlotsMasterDto>> Handle(UpdateSlotsMasterCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _slotsMasterRepository.FindBy(c => c.FacilityId == request.Id && c.Id != request.Id)
                .FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("SlotsMaster Name Already Exist.");
                return ServiceResponse<SlotsMasterDto>.Return409("SlotsMaster Name Already Exist.");
            }
            entityExist = await _slotsMasterRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            // entityExist.Name = request.Name;
            // entityExist.DisplayName = request.DisplayName;
            
            _slotsMasterRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<SlotsMasterDto>.Return500();
            }
            return ServiceResponse<SlotsMasterDto>.ReturnResultWith200(_mapper.Map<SlotsMasterDto>(entityExist));
        }
    }
}
