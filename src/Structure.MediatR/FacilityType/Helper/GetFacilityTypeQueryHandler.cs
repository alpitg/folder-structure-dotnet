using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Microsoft.Extensions.Logging;

namespace Structure.MediatR.Handlers
{
    public class GetFacilityTypeQueryHandler : IRequestHandler<GetFacilityTypeQuery, ServiceResponse<FacilityTypeDto>>
    {
        private readonly IFacilityTypeRepository _facilityRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFacilityTypeQueryHandler> _logger;

        public GetFacilityTypeQueryHandler(
            IFacilityTypeRepository facilityRepository,
            IMapper mapper,
            ILogger<GetFacilityTypeQueryHandler> logger)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ServiceResponse<FacilityTypeDto>> Handle(GetFacilityTypeQuery request, CancellationToken cancellationToken)
        {
            var entity = await _facilityRepository.FindAsync(request.Id);
            if (entity != null)
                return ServiceResponse<FacilityTypeDto>.ReturnResultWith200(_mapper.Map<FacilityTypeDto>(entity));
            else
            {
                _logger.LogError("Not found");
                return ServiceResponse<FacilityTypeDto>.Return404();
            }
        }
    }
}