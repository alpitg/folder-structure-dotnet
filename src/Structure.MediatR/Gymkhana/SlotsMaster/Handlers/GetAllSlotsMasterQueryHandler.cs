using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Structure.MediatR.Handlers
{
    public class GetAllSlotsMasterQueryHandler : IRequestHandler<GetAllSlotsMasterQuery, List<SlotsMasterDto>>
    {
        private readonly ISlotsMasterRepository _slotsMasterRepository;
        private readonly IMapper _mapper;

        public GetAllSlotsMasterQueryHandler(
            ISlotsMasterRepository slotsMasterRepository,
            IMapper mapper)
        {
            _slotsMasterRepository = slotsMasterRepository;
            _mapper = mapper;

        }
        public async Task<List<SlotsMasterDto>> Handle(GetAllSlotsMasterQuery request, CancellationToken cancellationToken)
        {
            var entities = await _slotsMasterRepository.All.OrderBy(c => c.Id).ToListAsync();
            return _mapper.Map<List<SlotsMasterDto>>(entities);
        }
    }
}
