using System.Data.Entity;

namespace PatientFollowUp.Web
{
    public abstract class BaseDomainContext : DbContext
    {
        static BaseDomainContext()
        {
            //Needed to fix EF - 
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}