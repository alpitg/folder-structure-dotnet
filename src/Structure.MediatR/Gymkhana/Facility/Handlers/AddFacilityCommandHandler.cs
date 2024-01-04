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
    public class AddFacilityCommandHandler : IRequestHandler<AddFacilityCommand, ServiceResponse<FacilityDto>>
    {
        private readonly IFacilityRepository _FacilityRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddFacilityCommandHandler> _logger;
        
        public AddFacilityCommandHandler(
           IFacilityRepository FacilityRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddFacilityCommandHandler> logger
            )
        {
            _FacilityRepository = FacilityRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<FacilityDto>> Handle(AddFacilityCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _FacilityRepository.FindBy(c => c.FacilityName == request.FacilityName).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Facility Already Exist");
                return ServiceResponse<FacilityDto>.Return409("Facility Already Exist.");
            }

            var entity = _mapper.Map<Facility>(request);
            entity.Id = Guid.NewGuid();
            _FacilityRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {
                _logger.LogError("Save Facility have Error");
                return ServiceResponse<FacilityDto>.Return500();
            }
            return ServiceResponse<FacilityDto>.ReturnResultWith200(_mapper.Map<FacilityDto>(entity));
        }
    }
}
