using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Structure.MediatR.Handlers
{
    public class GetTenantQueryHandler : IRequestHandler<GetTenantQuery, ServiceResponse<TenantDto>>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTenantQueryHandler> _logger;

        public GetTenantQueryHandler(
            ITenantRepository tenantRepository,
            IMapper mapper,
            ILogger<GetTenantQueryHandler> logger)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ServiceResponse<TenantDto>> Handle(GetTenantQuery request, CancellationToken cancellationToken)
        {
            var entity = await _tenantRepository
               .AllIncluding(c => c.Users)
               .Where(c => c.Id == request.Id)
               .FirstOrDefaultAsync();

            if (entity != null)
                return ServiceResponse<TenantDto>.ReturnResultWith200(_mapper.Map<TenantDto>(entity));
            else
            {
                _logger.LogError("Not found");
                return ServiceResponse<TenantDto>.Return404();
            }
        }
    }
}
