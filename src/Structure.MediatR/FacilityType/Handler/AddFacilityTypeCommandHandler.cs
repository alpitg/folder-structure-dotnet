using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class AddFacilityTypeCommandHandler : IRequestHandler<AddFacilityTypeCommands, ServiceResponse<FacilityTypeDto>>
    {

        private readonly IFacilityTypeRepository _facilityTypeRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddFacilityTypeCommandHandler> _logger;

        public AddFacilityTypeCommandHandler(
           IFacilityTypeRepository facilityTypeRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddFacilityTypeCommandHandler> logger
            )
        {
            _facilityTypeRepository = facilityTypeRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }

        public async Task<ServiceResponse<FacilityTypeDto>> Handle(AddFacilityTypeCommands request, CancellationToken cancellationToken)
        {
            var existingEntity = await _facilityTypeRepository.FindBy(c => c.Name == request.Name).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Page Already Exist");
                return ServiceResponse<FacilityTypeDto>.Return409("Page Already Exist.");
            }
            var existingOrder = await _facilityTypeRepository.FindBy(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (existingOrder != null)
            {
                _logger.LogError("Order Number Already Exist");
                return ServiceResponse<FacilityTypeDto>.Return409("Order Number Already Exist.");
            }

            var entity = _mapper.Map<FacilityType>(request);
            entity.Id = Guid.NewGuid();
            _facilityTypeRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {

                _logger.LogError("Save Page have Error");
                return ServiceResponse<FacilityTypeDto>.Return500();
            }
            return ServiceResponse<FacilityTypeDto>.ReturnResultWith200(_mapper.Map<FacilityTypeDto>(entity));
        }
    }
}
