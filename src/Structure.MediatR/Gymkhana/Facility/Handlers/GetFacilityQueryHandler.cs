using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Microsoft.Extensions.Logging;

namespace Structure.MediatR.Handlers
{
    public class GetFacilityQueryHandler : IRequestHandler<GetFacilityQuery, ServiceResponse<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFacilityQueryHandler> _logger;

        public GetFacilityQueryHandler(
            IFacilityRepository facilityRepository,
            IMapper mapper,
            ILogger<GetFacilityQueryHandler> logger)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ServiceResponse<FacilityDto>> Handle(GetFacilityQuery request, CancellationToken cancellationToken)
        {
            var entity = await _facilityRepository.FindAsync(request.Id);
            if (entity != null)
                return ServiceResponse<FacilityDto>.ReturnResultWith200(_mapper.Map<FacilityDto>(entity));
            else
            {
                _logger.LogError("Not found");
                return ServiceResponse<FacilityDto>.Return404();
            }
        }
    }
}
