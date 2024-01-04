using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Microsoft.Extensions.Logging;

namespace Structure.MediatR.Handlers
{
    public class GetSlotsMasterQueryHandler : IRequestHandler<GetSlotsMasterQuery, ServiceResponse<SlotsMasterDto>>
    {
        private readonly ISlotsMasterRepository _slotsMasterRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSlotsMasterQueryHandler> _logger;

        public GetSlotsMasterQueryHandler(
            ISlotsMasterRepository slotsMasterRepository,
            IMapper mapper,
            ILogger<GetSlotsMasterQueryHandler> logger)
        {
            _slotsMasterRepository = slotsMasterRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ServiceResponse<SlotsMasterDto>> Handle(GetSlotsMasterQuery request, CancellationToken cancellationToken)
        {
            var entity = await _slotsMasterRepository.FindAsync(request.Id);
            if (entity != null)
                return ServiceResponse<SlotsMasterDto>.ReturnResultWith200(_mapper.Map<SlotsMasterDto>(entity));
            else
            {
                _logger.LogError("Not found");
                return ServiceResponse<SlotsMasterDto>.Return404();
            }
        }
    }
}
