using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Structure.MediatR.Handlers
{
    public class GetAllTenantQueryHandler : IRequestHandler<GetAllTenantQuery, List<TenantDto>>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;

        public GetAllTenantQueryHandler(
            ITenantRepository tenantRepository,
            IMapper mapper)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;

        }
        public async Task<List<TenantDto>> Handle(GetAllTenantQuery request, CancellationToken cancellationToken)
        {
            var entities = await _tenantRepository.All.ToListAsync();
            return _mapper.Map<List<TenantDto>>(entities);
        }
    }
}
