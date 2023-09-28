using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository.UnitOfWork;
using Structure.Repository;
using Microsoft.EntityFrameworkCore;
using Structure.Data;

namespace Structure.MediatR.Handlers
{
    public class AddTenantCommandHandler : IRequestHandler<AddTenantCommand, ServiceResponse<TenantDto>>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddTenantCommandHandler> _logger;
        public AddTenantCommandHandler(
           ITenantRepository tenantRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddTenantCommandHandler> logger
            )
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }

        public async Task<ServiceResponse<TenantDto>> Handle(AddTenantCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _tenantRepository.FindBy(c => c.Name == request.Name).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Tenant Already Exist");
                return ServiceResponse<TenantDto>.Return409("Tenant Already Exist.");
            }

            var entity = _mapper.Map<Tenant>(request);
            entity.Id = Guid.NewGuid();
            _tenantRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {
                _logger.LogError("Save Tenant have Error");
                return ServiceResponse<TenantDto>.Return500();
            }
            return ServiceResponse<TenantDto>.ReturnResultWith200(_mapper.Map<TenantDto>(entity));
        }
    }
}
