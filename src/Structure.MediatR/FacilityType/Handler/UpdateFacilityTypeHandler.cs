using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository.UnitOfWork;
using Structure.Repository;


using Microsoft.EntityFrameworkCore;

namespace Structure.MediatR.Handlers
{
    public class UpdateFacilityTypeHandler : IRequestHandler<UpdateFacilityTypeCommands, ServiceResponse<FacilityTypeDto>>
    {
        private readonly IFacilityTypeRepository _facilityTypeRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFacilityTypeHandler> _logger;
        public UpdateFacilityTypeHandler(
           IFacilityTypeRepository facilityTypeRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<UpdateFacilityTypeHandler> logger
            )
        {
            _facilityTypeRepository = facilityTypeRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
       
        public async Task<ServiceResponse<FacilityTypeDto>> Handle(UpdateFacilityTypeCommands request, CancellationToken cancellationToken)
        {
            var entityExist = await _facilityTypeRepository.FindBy(c => c.Name == request.Name && c.Id != request.Id)
               .FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("Page Name Already Exist.");
                return ServiceResponse<FacilityTypeDto>.Return409("Page Name Already Exist.");
            }
            entityExist = await _facilityTypeRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            entityExist.Name = request.Name;
            _facilityTypeRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<FacilityTypeDto>.Return500();
            }
            return ServiceResponse<FacilityTypeDto>.ReturnResultWith200(_mapper.Map<FacilityTypeDto>(entityExist));
        }
    }
}

