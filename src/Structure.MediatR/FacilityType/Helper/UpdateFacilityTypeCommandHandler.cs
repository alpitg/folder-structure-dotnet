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
    public class UpdateFacilityTypeCommandHandler : IRequestHandler<UpdateFacilityTypeCommand, ServiceResponse<FacilityTypeDto>>
    {
        private readonly IFacilityTypeRepository _facilityRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFacilityTypeCommandHandler> _logger;

        public UpdateFacilityTypeCommandHandler(
           IFacilityTypeRepository facilityRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<UpdateFacilityTypeCommandHandler> logger
            )
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<FacilityTypeDto>> Handle(UpdateFacilityTypeCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _facilityRepository.FindBy(c => c.Name == request.Name && c.Id != request.Id)
                .FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("Facility Name Already Exist.");
                return ServiceResponse<FacilityTypeDto>.Return409("Facility Name Already Exist.");
            }
            entityExist = await _facilityRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            entityExist.Name = request.Name;

            _facilityRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<FacilityTypeDto>.Return500();
            }
            return ServiceResponse<FacilityTypeDto>.ReturnResultWith200(_mapper.Map<FacilityTypeDto>(entityExist));
        }
    }
}
