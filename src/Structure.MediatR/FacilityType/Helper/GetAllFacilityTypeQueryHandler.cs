using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Structure.MediatR.Handlers
{
    public class GetAllFacilityTypeQueryHandler : IRequestHandler<GetAllFacilityTypeQuery, List<FacilityTypeDto>>
    {
        private readonly IFacilityTypeRepository _facilityRepository;
        private readonly IMapper _mapper;

        public GetAllFacilityTypeQueryHandler(
            IFacilityTypeRepository facilityRepository,
            IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;

        }
        public async Task<List<FacilityTypeDto>> Handle(GetAllFacilityTypeQuery request, CancellationToken cancellationToken)
        {
            var entities = await _facilityRepository.All.OrderBy(c => c.Name).ToListAsync();
            return _mapper.Map<List<FacilityTypeDto>>(entities);
        }
    }
}