using Structure.Data;
using Structure.Domain;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;

namespace Structure.Repository
{
    public class BookSlotsRepository : GenericRepository<BookSlots, StructureDbContext>,
        IBookSlotsRepository
    {
        public BookSlotsRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        { }
    }
}
