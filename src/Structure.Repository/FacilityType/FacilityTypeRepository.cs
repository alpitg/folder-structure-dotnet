﻿using Structure.Data;
using Structure.Domain;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;

namespace Structure.Repository
{
    public class FacilityTypeRepository : GenericRepository<FacilityType, StructureDbContext>,
        IFacilityTypeRepository
    {

        public FacilityTypeRepository(
            IUnitOfWork<StructureDbContext> uow) : base(uow) { 
        }
    }
}
