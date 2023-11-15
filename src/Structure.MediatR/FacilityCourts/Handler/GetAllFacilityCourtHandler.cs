using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Data.Dto;
using Structure.MediatR.Commands;
using Structure.Repository;


namespace Structure.MediatR.Handler
{
    public class GetAllFacilityCourtHandler : IRequestHandler<GetAllFacilityCourtCommand , List<FacilityCourtsDto>>
    {

        private readonly IFacilityCourtRepository _facilityCourtRepository;
        private readonly IMapper _mapper;

        public GetAllFacilityCourtHandler(
           IFacilityCourtRepository facilityCourtRepository,
           IMapper mapper)
        {
            _facilityCourtRepository = facilityCourtRepository;
            _mapper = mapper;

        }

        public async Task<List<FacilityCourtsDto>> Handle(GetAllFacilityCourtCommand request, CancellationToken cancellationToken)
        {
            var entities = await _facilityCourtRepository.All.OrderBy(c => c.CourtName).ToListAsync();
            return _mapper.Map<List<FacilityCourtsDto>>(entities);
        }
    }
}
