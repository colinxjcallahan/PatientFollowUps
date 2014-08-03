using FluentValidation;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web.App_Data
{
    public class SaveFollowUpUpdatesInputModelValidator : AbstractValidator<SaveFollowUpUpdatesInputModel>, IValidator
    {
        public SaveFollowUpUpdatesInputModelValidator()
        {
            RuleFor(x => x.FollowUpExamId)
                .NotNull()
                .GreaterThan(0)
                .When(x => x.NoRelevantFollowUpFound == false)
                .WithMessage("Either select an exam ID or select 'No Relevant Followup' and add a comment");
        }
        public new ValidationResult Validate(SaveFollowUpUpdatesInputModel saveFollowUpUpdatesInputModel)
        {
            var fluentValidationResult = base.Validate(saveFollowUpUpdatesInputModel);
            var validationResult = new ValidationResult();
            if (!fluentValidationResult.IsValid)
            {
                foreach (var validationFailure in fluentValidationResult.Errors)
                {
                    validationResult.AddError(validationFailure.ErrorMessage);
                }
            }
            return validationResult;
        }
    }
}