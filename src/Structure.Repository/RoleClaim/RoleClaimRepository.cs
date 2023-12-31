﻿using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;
using Structure.Data;
using Structure.Domain;

namespace Structure.Repository
{
    public class RoleClaimRepository : GenericRepository<RoleClaim, StructureDbContext>,
           IRoleClaimRepository
    {
        public RoleClaimRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}