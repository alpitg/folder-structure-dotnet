using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Data.Dto;
using Structure.MediatR.Commands;
using Structure.Repository;

namespace Structure.MediatR.Handler
{
    public class GetAllFacilityTypeHandler : IRequestHandler<GetAllFacilityTypeQuery, List<FacilityTypeDto>>
    {
        private readonly IFacilityTypeRepository _facilityTypeRepository;
        private readonly IMapper _mapper;

        public GetAllFacilityTypeHandler(
            IFacilityTypeRepository facilityTypeRepository,
            IMapper mapper)
        {
            _facilityTypeRepository = facilityTypeRepository;
            _mapper = mapper;

        }
        public async Task<List<FacilityTypeDto>> Handle(GetAllFacilityTypeQuery reqest, CancellationToken cancellationToken)
        {
            var entities = await _facilityTypeRepository.All.OrderBy(c => c.Name).ToListAsync();
            return _mapper.Map<List<FacilityTypeDto>>(entities);
        }
    }
}
