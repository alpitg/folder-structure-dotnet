using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository;
using Structure.Repository.UnitOfWork;


namespace Structure.MediatR.Handler
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
            var entityExist = await _facilityRepository.FindBy(c => c.Name == request.Name && c.Id != request.Id).FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("Name Already Exist.");
                return ServiceResponse<FacilityDto>.Return409("Name Already Exist.");
            }
            entityExist = await _facilityRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            entityExist.Name = request.Name;
            entityExist.IsHavingMultipleCourts = request.IsHavingMultipleCourts;
            entityExist.FacilityType = request.FacilityType;
            entityExist.FacilityTypeId = request.FacilityId;
            _facilityRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<FacilityDto>.Return500();
            }
            return ServiceResponse<FacilityDto>.ReturnResultWith200(_mapper.Map<FacilityDto>(entityExist));
        }

    }
}
