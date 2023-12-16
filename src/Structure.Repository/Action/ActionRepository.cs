using Structure.Domain.Entities;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;

namespace Structure.Repository
{
    public class ActionRepository : GenericRepository<Domain.Entities.Action, StructureDbContext>,
          IActionRepository
    {
        public ActionRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}
