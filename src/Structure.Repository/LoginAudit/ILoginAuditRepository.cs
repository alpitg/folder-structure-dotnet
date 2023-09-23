using Structure.Common.GenericRepository;
using Structure.Data;
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
