using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Structure.MediatR.Handlers
{
    public class GetAllFacilityQueryHandler : IRequestHandler<GetAllFacilityQuery, List<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public GetAllFacilityQueryHandler(
            IFacilityRepository facilityRepository,
            IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;

        }
        public async Task<List<FacilityDto>> Handle(GetAllFacilityQuery request, CancellationToken cancellationToken)
        {
            var entities = await _facilityRepository.All.OrderBy(c => c.FacilityName).ToListAsync();
            return _mapper.Map<List<FacilityDto>>(entities);
        }
    }
}
