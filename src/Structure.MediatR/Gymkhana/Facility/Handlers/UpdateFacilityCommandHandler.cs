using AutoMapper;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Helper;
using Microsoft.Extensions.Logging;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class UpdateFacilityCommandHandler : IRequestHandler<UpdateFacilityCommand, ServiceResponse<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFacilityCommandHandler> _logger;

        public UpdateFacilityCommandHandler(
           IFacilityRepository facilityRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<UpdateFacilityCommandHandler> logger
            )
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<FacilityDto>> Handle(UpdateFacilityCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _facilityRepository.FindBy(c => c.FacilityName == request.FacilityName && c.Id != request.Id)
                .FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("Facility Name Already Exist.");
                return ServiceResponse<FacilityDto>.Return409("Facility Name Already Exist.");
            }
            entityExist = await _facilityRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            entityExist.FacilityName = request.FacilityName;
            
            _facilityRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<FacilityDto>.Return500();
            }
            return ServiceResponse<FacilityDto>.ReturnResultWith200(_mapper.Map<FacilityDto>(entityExist));
        }
    }
}
