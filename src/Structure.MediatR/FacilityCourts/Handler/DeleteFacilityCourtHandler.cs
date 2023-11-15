using MediatR;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository.UnitOfWork;
using Structure.Repository;

namespace Structure.MediatR.Handler
{
    public class DeleteFacilityCourtHandler : IRequestHandler<DeleteFacilityCourtCommand, ServiceResponse<FacilityCourtsDto>>
    {

        private readonly IFacilityCourtRepository _facilityCourtRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;

        public DeleteFacilityCourtHandler(
         IFacilityCourtRepository facilityCourtRepository,
          IUnitOfWork<StructureDbContext> uow
          )
        {
            _facilityCourtRepository = facilityCourtRepository;
            _uow = uow;
        }

        public async Task<ServiceResponse<FacilityCourtsDto>> Handle(DeleteFacilityCourtCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _facilityCourtRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                return ServiceResponse<FacilityCourtsDto>.Return404();
            }
            _facilityCourtRepository.Delete(request.Id);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<FacilityCourtsDto>.Return500();
            }
            return ServiceResponse<FacilityCourtsDto>.ReturnSuccess();
        }
    }
}
