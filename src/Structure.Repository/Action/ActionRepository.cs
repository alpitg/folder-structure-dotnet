using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;
using Structure.Data;
using Structure.Domain;

namespace Structure.Repository
{
    public class ActionRepository : GenericRepository<Data.Action, StructureDbContext>,
          IActionRepository
    {
        public ActionRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}
