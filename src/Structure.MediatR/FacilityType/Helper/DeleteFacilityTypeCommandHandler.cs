using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class DeleteFacilityTypeCommandHandler : IRequestHandler<DeleteFacilityTypeCommand, ServiceResponse<FacilityTypeDto>>
    {
        private readonly IFacilityTypeRepository _facilityRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;

        public DeleteFacilityTypeCommandHandler(
           IFacilityTypeRepository FacilityRepository,
            IUnitOfWork<StructureDbContext> uow
            )
        {
            _facilityRepository = FacilityRepository;
            _uow = uow;
        }

        public async Task<ServiceResponse<FacilityTypeDto>> Handle(DeleteFacilityTypeCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _facilityRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                return ServiceResponse<FacilityTypeDto>.Return404();
            }
            _facilityRepository.Delete(request.Id);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<FacilityTypeDto>.Return500();
            }
            return ServiceResponse<FacilityTypeDto>.ReturnSuccess();
        }
    }
}