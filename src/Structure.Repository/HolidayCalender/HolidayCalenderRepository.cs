using Structure.Data;
using Structure.Domain;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;


namespace Structure.Repository
{
    public class HolidayCalenderRepository : GenericRepository<HolidayCalenders,StructureDbContext>,
        IHolidayCalenderRepository
    {

        public HolidayCalenderRepository(
            IUnitOfWork<StructureDbContext> uow 
            ) : base(uow) 
        { }

    }
}
