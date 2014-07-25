using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web.App_Data
{
    public interface IValidator
    {
        ValidationResult Validate(SaveFollowUpUpdatesInputModel saveFollowUpUpdatesInputModel);
    }
}