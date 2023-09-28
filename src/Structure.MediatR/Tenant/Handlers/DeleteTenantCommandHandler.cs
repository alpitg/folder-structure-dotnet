using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class DeleteTenantCommandHandler : IRequestHandler<DeleteTenantCommand, ServiceResponse<TenantDto>>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        public DeleteTenantCommandHandler(
           ITenantRepository tenantRepository,
            IUnitOfWork<StructureDbContext> uow
            )
        {
            _tenantRepository = tenantRepository;
            _uow = uow;
        }

        public async Task<ServiceResponse<TenantDto>> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _tenantRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                return ServiceResponse<TenantDto>.Return404();
            }
            _tenantRepository.Delete(request.Id);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<TenantDto>.Return500();
            }
            return ServiceResponse<TenantDto>.ReturnSuccess();
        }
    }
}
