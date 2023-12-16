using Structure.Repository.GenericRepository;
using Structure.Domain.Entities;
using Structure.Data.Dto;
using Structure.Data.Resources;

namespace Structure.Repository
{
    public interface ILoginAuditRepository : IGenericRepository<LoginAudit>
    {
        Task<LoginAuditList> GetDocumentAuditTrails(LoginAuditResource loginAuditResrouce);
        Task LoginAudit(LoginAuditDto loginAudit);
    }
}
