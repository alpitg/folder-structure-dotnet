using MediatR;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository.UnitOfWork;
using Structure.Repository;


namespace Structure.MediatR.Handler
{
     public class DeleteFacilityHandler : IRequestHandler<DeleteFacilityCommand, ServiceResponse<FacilityDto>>
    {

        private readonly IFacilityRepository _facilityRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;

        public DeleteFacilityHandler(
        IFacilityRepository facilityRepository,
         IUnitOfWork<StructureDbContext> uow
         )
        {
            _facilityRepository = facilityRepository;
            _uow = uow;
        }


        public async Task<ServiceResponse<FacilityDto>> Handle(DeleteFacilityCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _facilityRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                return ServiceResponse<FacilityDto>.Return404();
            }
            _facilityRepository.Delete(request.Id);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<FacilityDto>.Return500();
            }
            return ServiceResponse<FacilityDto>.ReturnSuccess();
        }

    }
}
