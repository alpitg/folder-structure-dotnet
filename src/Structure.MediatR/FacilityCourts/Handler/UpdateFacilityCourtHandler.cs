using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository.UnitOfWork;
using Structure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Structure.MediatR.Handler
{
    public class UpdateFacilityCourtHandler : IRequestHandler<UpdateFacilityCourtCommand, ServiceResponse<FacilityCourtsDto>>
    {

        private readonly IFacilityCourtRepository _facilityCourtRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFacilityCourtHandler> _logger;

        public UpdateFacilityCourtHandler(
         IFacilityCourtRepository facilityCourtRepository,
          IMapper mapper,
          IUnitOfWork<StructureDbContext> uow,
          ILogger<UpdateFacilityCourtHandler> logger
          )
        {
            _facilityCourtRepository = facilityCourtRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }

        public async Task<ServiceResponse<FacilityCourtsDto>> Handle(UpdateFacilityCourtCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _facilityCourtRepository.FindBy(c => c.CourtName == request.CourtName && c.Id != request.Id)
                .FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("Page Name Already Exist.");
                return ServiceResponse<FacilityCourtsDto>.Return409("Page Name Already Exist.");
            }
            entityExist = await _facilityCourtRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            entityExist.CourtName = request.CourtName;
            entityExist.CourtNumber = request.CourtNumber;
            _facilityCourtRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<FacilityCourtsDto>.Return500();
            }
            return ServiceResponse<FacilityCourtsDto>.ReturnResultWith200(_mapper.Map<FacilityCourtsDto>(entityExist));
        }

    }
}
