using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class DeleteFacilityCommandHandler : IRequestHandler<DeleteFacilityCommand, ServiceResponse<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;

        public DeleteFacilityCommandHandler(
           IFacilityRepository FacilityRepository,
            IUnitOfWork<StructureDbContext> uow
            )
        {
            _facilityRepository = FacilityRepository;
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
