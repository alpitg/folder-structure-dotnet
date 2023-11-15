using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Data.Dto;
using Structure.MediatR.Commands;
using Structure.Repository;



namespace Structure.MediatR.Handler
{
    public class GetAllFacilityCommandHandler : IRequestHandler<GetAllFacilityCommand, List<FacilityDto>>
    {

        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public GetAllFacilityCommandHandler(
            IFacilityRepository facilityRepository,
            IMapper mapper )
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<List<FacilityDto>> Handle(GetAllFacilityCommand request, CancellationToken cancellationToken)
        {
            var entities = await _facilityRepository.All.OrderBy(c => c.Name).ToListAsync();
            return _mapper.Map<List<FacilityDto>>(entities);
        }

    }
}
