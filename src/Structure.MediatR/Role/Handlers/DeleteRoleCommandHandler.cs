using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using MediatR;
using Structure.Repository;
using Structure.Repository.UnitOfWork;
using Structure.Helper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Structure.Domain.Entities;

namespace Structure.MediatR.Handlers
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, ServiceResponse<RoleDto>>
    {
        private readonly UserInfoToken _userInfoToken;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly ILogger<DeleteRoleCommandHandler> _logger;
        public DeleteRoleCommandHandler(
            UserInfoToken userInfoToken,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<DeleteRoleCommandHandler> logger
            )
        {
            _userInfoToken = userInfoToken;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _uow = uow;
            _logger = logger;
        }

        public async Task<ServiceResponse<RoleDto>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _roleRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                _logger.LogError("Not found");
                return ServiceResponse<RoleDto>.Return404();
            }

            if (entityExist.IsSuperRole)
            {
                _logger.LogError("Super admin Role can not be Deleted.");
                return ServiceResponse<RoleDto>.Return409("Super admin Role can not be Deleted.");
            }

            var exitingRole = await _userRoleRepository.All.AnyAsync(c => c.RoleId == entityExist.Id);
            if (exitingRole)
            {
                _logger.LogError("Role can not be Deleted because it is assign to User");
                return ServiceResponse<RoleDto>.Return409("Role can not be Deleted because it is assign to User");
            }
            entityExist.IsDeleted = true;
            entityExist.DeletedBy = Guid.Parse(_userInfoToken.Id);
            entityExist.DeletedDate = DateTime.UtcNow;
            _roleRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<RoleDto>.Return500();
            }
            return ServiceResponse<RoleDto>.ReturnResultWith204();
        }
    }
}
