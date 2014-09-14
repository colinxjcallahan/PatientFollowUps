using System.Data.Entity;

namespace PatientFollowUp.Web
{
    public abstract class BaseDomainContext : DbContext
    {
        static BaseDomainContext()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}