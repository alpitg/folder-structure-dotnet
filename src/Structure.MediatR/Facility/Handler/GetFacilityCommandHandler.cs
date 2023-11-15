using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Structure.Data.Dto;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository;


namespace Structure.MediatR.Handler
{
    public class GetFacilityCommandHandler : IRequestHandler<GetFacilityCommand, ServiceResponse<FacilityDto>>
    {

        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFacilityCommandHandler> _logger;

        public GetFacilityCommandHandler(
            IFacilityRepository facilityRepository,
            IMapper mapper,
            ILogger<GetFacilityCommandHandler> logger)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<FacilityDto>> Handle(GetFacilityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _facilityRepository.FindAsync(request.Id);
            if(entity != null)
                return ServiceResponse<FacilityDto>.ReturnResultWith200(_mapper.Map<FacilityDto>(entity));
            else
            {
                _logger.LogError("Not Found");
                return ServiceResponse<FacilityDto>.Return404();
            }
        }

    }
}
