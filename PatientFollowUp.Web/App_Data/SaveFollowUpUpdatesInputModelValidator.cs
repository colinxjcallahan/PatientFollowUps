using FluentValidation;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web.App_Data
{
    //public class SaveFollowUpUpdatesInputModelValidator : AbstractValidator<SaveFollowUpUpdatesInputModel>, IValidator
    //{
    //    public new ValidationResult Validate(SaveFollowUpUpdatesInputModel saveFollowUpUpdatesInputModel)
    //    {
    //        var fluentValidationResult = base.Validate(saveFollowUpUpdatesInputModel);
    //        var validationResult = new ValidationResult();
    //        if (!fluentValidationResult.IsValid)
    //        {
    //            foreach (var validationFailure in fluentValidationResult.Errors)
    //            {
    //                validationResult.AddError(validationFailure.ErrorMessage);
    //            }
    //        }
    //        return validationResult;
    //    }
    //}

    public class SaveFollowUpUpdatesInputModelValidator : IValidator
    {
        public new ValidationResult Validate(SaveFollowUpUpdatesInputModel saveFollowUpUpdatesInputModel)
        {
            return new ValidationResult
            {
                IsValid = true,
            };
        }
    }
}