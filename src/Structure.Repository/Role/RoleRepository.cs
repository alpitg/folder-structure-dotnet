using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;
using Structure.Domain.Entities;
using Structure.Domain;

namespace Structure.Repository
{
    public  class RoleRepository : GenericRepository<Role, StructureDbContext>,
          IRoleRepository
    {
        public RoleRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}