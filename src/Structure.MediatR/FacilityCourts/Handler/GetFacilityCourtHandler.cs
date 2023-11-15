using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Structure.Data.Dto;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository;

namespace Structure.MediatR.Handler
{
    public class GetFacilityCourtHandler : IRequestHandler<GetFacilityCourtCommand, ServiceResponse<FacilityCourtsDto>>
    {

        private readonly IFacilityCourtRepository _facilityCourtRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFacilityCourtHandler> _logger;

        public GetFacilityCourtHandler(
           IFacilityCourtRepository facilityCourtRepository,
           IMapper mapper,
           ILogger<GetFacilityCourtHandler> logger)
        {
            _facilityCourtRepository = facilityCourtRepository;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<ServiceResponse<FacilityCourtsDto>> Handle(GetFacilityCourtCommand request, CancellationToken cancellationToken)
        {
            var entity = await _facilityCourtRepository.FindAsync(request.Id);
            if (entity != null)
                return ServiceResponse<FacilityCourtsDto>.ReturnResultWith200(_mapper.Map<FacilityCourtsDto>(entity));
            else
            {
                _logger.LogError("Not found");
                return ServiceResponse<FacilityCourtsDto>.Return404();
            }
        }

    }
}
