using AutoMapper;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Helper;
using Microsoft.Extensions.Logging;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, ServiceResponse<TenantDto>>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTenantCommandHandler> _logger;
        public UpdateTenantCommandHandler(
           ITenantRepository tenantRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<UpdateTenantCommandHandler> logger
            )
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<TenantDto>> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _tenantRepository.FindBy(c => c.Name == request.Name && c.Id != request.Id)
                .FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("Tenant Name Already Exist.");
                return ServiceResponse<TenantDto>.Return409("Tenant Name Already Exist.");
            }
            entityExist = await _tenantRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            entityExist.Name = request.Name;
            _tenantRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<TenantDto>.Return500();
            }
            return ServiceResponse<TenantDto>.ReturnResultWith200(_mapper.Map<TenantDto>(entityExist));
        }
    }
}
