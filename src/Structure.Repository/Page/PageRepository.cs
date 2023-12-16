using Structure.Domain.Entities;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;

namespace Structure.Repository
{
    public class PageRepository : GenericRepository<Page, StructureDbContext>,
          IPageRepository
    {
        public PageRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}
