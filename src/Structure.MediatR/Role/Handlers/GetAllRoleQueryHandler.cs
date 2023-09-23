using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Structure.MediatR.Handlers
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<RoleDto>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllRoleQueryHandler> _logger;

        public GetAllRoleQueryHandler(
           IRoleRepository roleRepository,
            IMapper mapper,
            ILogger<GetAllRoleQueryHandler> logger)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<List<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var entities = await _roleRepository.All.ToListAsync();
            return _mapper.Map<List<RoleDto>>(entities);
        }
    }
}
