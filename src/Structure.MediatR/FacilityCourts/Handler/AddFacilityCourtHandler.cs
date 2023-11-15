using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Structure.Data;
using Structure.Repository;

namespace Structure.MediatR.Handler
{
    public class AddFacilityCourtHandler : IRequestHandler<AddFacilityCourtsCommands , ServiceResponse<FacilityCourtsDto>>
    {

        private readonly IFacilityCourtRepository _facilityCourtRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddFacilityCourtHandler> _logger;


        public AddFacilityCourtHandler(
          IFacilityCourtRepository facilityCourtRepository,
           IMapper mapper,
           IUnitOfWork<StructureDbContext> uow,
           ILogger<AddFacilityCourtHandler> logger
           )
        {
            _facilityCourtRepository = facilityCourtRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }

        public async Task<ServiceResponse<FacilityCourtsDto>> Handle(AddFacilityCourtsCommands request, CancellationToken cancellationToken)
        {
            var existingEntity = await _facilityCourtRepository.FindBy(c => c.CourtName == request.CourtName).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Page Already Exist");
                return ServiceResponse<FacilityCourtsDto>.Return409("Page Already Exist.");
            }
            var existingOrder = await _facilityCourtRepository.FindBy(c => c.CourtFees == request.CourtFees).FirstOrDefaultAsync();
            if (existingOrder != null)
            {
                _logger.LogError("Order Number Already Exist");
                return ServiceResponse<FacilityCourtsDto>.Return409("Court fees Already Exist.");
            }
            var existingNumber = await _facilityCourtRepository.FindBy(c => c.CourtNumber == request.CourtNumber).FirstOrDefaultAsync();
            if (existingNumber != null)
            {
                _logger.LogError("Order Number Already Exist");
                return ServiceResponse<FacilityCourtsDto>.Return409("Court Number Already Exist.");
            }

            var entity = _mapper.Map<FacilitiesCourts>(request);
            entity.Id = Guid.NewGuid();
            _facilityCourtRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {

                _logger.LogError("Save Page have Error");
                return ServiceResponse<FacilityCourtsDto>.Return500();
            }
            return ServiceResponse<FacilityCourtsDto>.ReturnResultWith200(_mapper.Map<FacilityCourtsDto>(entity));
        }
    }
}
