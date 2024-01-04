using AutoMapper;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Structure.Helper;
using Structure.Repository.UnitOfWork;
using Structure.Data;
using Structure.Repository;

namespace Structure.MediatR.Handlers
{
    public class AddFacilityTypeCommandHandler : IRequestHandler<AddFacilityTypeCommand, ServiceResponse<FacilityTypeDto>>
    {
        private readonly IFacilityTypeRepository _FacilityRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddFacilityTypeCommandHandler> _logger;

        public AddFacilityTypeCommandHandler(
           IFacilityTypeRepository FacilityRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddFacilityTypeCommandHandler> logger
            )
        {
            _FacilityRepository = FacilityRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<FacilityTypeDto>> Handle(AddFacilityTypeCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _FacilityRepository.FindBy(c => c.Name == request.Name).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Facility Already Exist");
                return ServiceResponse<FacilityTypeDto>.Return409("Facility Already Exist.");
            }

            var entity = _mapper.Map<FacilityTypes>(request);
            entity.Id = Guid.NewGuid();
            _FacilityRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {
                _logger.LogError("Save Facility have Error");
                return ServiceResponse<FacilityTypeDto>.Return500();
            }
            return ServiceResponse<FacilityTypeDto>.ReturnResultWith200(_mapper.Map<FacilityTypeDto>(entity));
        }
    }
}