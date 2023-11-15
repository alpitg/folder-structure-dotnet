using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handler
{
    public class AddFacilityHandler : IRequestHandler<AddFacilityCommand, ServiceResponse<FacilityDto>>
    {

        private readonly IFacilityRepository _facilityRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddFacilityHandler> _logger;

        public AddFacilityHandler(
            IFacilityRepository facilityRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddFacilityHandler> logger
            )
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }

        public async Task<ServiceResponse<FacilityDto>> Handle(AddFacilityCommand request, CancellationToken cancellationToken)
        {

            var existingEntity = await _facilityRepository.FindBy(c => c.Name == request.Name).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Name alredy exist");
                return ServiceResponse<FacilityDto>.Return409("Name alredy exist");
            }

            var entity = _mapper.Map<Facility>(request);
            entity.Id = Guid.NewGuid();
            _facilityRepository.Add(entity);
            if(await _uow.SaveAsync() <= 0)
            {
                _logger.LogError("Save Page Have error");
                return ServiceResponse<FacilityDto>.Return500();
            }
            return ServiceResponse<FacilityDto>.ReturnResultWith200(_mapper.Map<FacilityDto>(entity));
        }


    }
}
