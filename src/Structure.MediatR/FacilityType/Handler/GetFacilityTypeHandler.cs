using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Structure.Data.Dto;
using Structure.Helper;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;


namespace Structure.MediatR.Handler
{
    public class GetFacilityTypeHandler : IRequestHandler<GetFacilityTypeQuery, ServiceResponse<FacilityTypeDto>>
    {

        private readonly IFacilityTypeRepository _facilityTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFacilityTypeHandler> _logger;

        public GetFacilityTypeHandler(
            IFacilityTypeRepository facilityTypeRepository,
            IMapper mapper,
            ILogger<GetFacilityTypeHandler> logger)
        {
            _facilityTypeRepository = facilityTypeRepository;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<ServiceResponse<FacilityTypeDto>> Handle(GetFacilityTypeQuery request, CancellationToken cancellationToken)
        {
            var entity = await _facilityTypeRepository.FindAsync(request.Id);
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
