using MediatR;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;

using Structure.Repository.UnitOfWork;
using Structure.Repository;
using Structure.MediatR.CommandAndQuery;

namespace Structure.MediatR.Handler
{
    public class DeleteFacilityTypeHandler : IRequestHandler<DeleteFacilityTypeCommands, ServiceResponse<FacilityTypeDto>>
    {

        private readonly IFacilityTypeRepository _facilityTypeRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;

        public DeleteFacilityTypeHandler(
           IFacilityTypeRepository facilityTypeRepository,
            IUnitOfWork<StructureDbContext> uow
            )
        {
            _facilityTypeRepository = facilityTypeRepository;
            _uow = uow;
        }

        public async Task<ServiceResponse<FacilityTypeDto>> Handle(DeleteFacilityTypeCommands request, CancellationToken cancellationToken)
        {
            var entityExist = await _facilityTypeRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                return ServiceResponse<FacilityTypeDto>.Return404();
            }
            _facilityTypeRepository.Delete(request.Id);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<FacilityTypeDto>.Return500();
            }
            return ServiceResponse<FacilityTypeDto>.ReturnSuccess();
        }

    }
}
