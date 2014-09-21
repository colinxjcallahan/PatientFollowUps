using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web.Application
{
    public interface IValidator
    {
        ValidationResult Validate(SaveFollowUpUpdatesInputModel saveFollowUpUpdatesInputModel);
    }
}