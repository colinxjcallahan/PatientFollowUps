using FluentValidation;
using FluentValidation.Results;
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
                .WithMessage("Either select an exam ID or select 'No Relevant Followup' and select a Reason");

            RuleFor(x => x.FollowUpClosedReasonId)
                .NotNull()
                .GreaterThan(0)
                .When(x => x.NoRelevantFollowUpFound == true)
                .WithMessage("You must select a reason when closing with no relevant exam found");
        }

        public new ValidationResult Validate(SaveFollowUpUpdatesInputModel saveFollowUpUpdatesInputModel)
        {
            FluentValidation.Results.ValidationResult fluentValidationResult =
                base.Validate(saveFollowUpUpdatesInputModel);

            var validationResult = new ValidationResult();

            validationResult.IsValid = fluentValidationResult.IsValid;
            foreach (ValidationFailure validationFailure in fluentValidationResult.Errors)
            {
                validationResult.AddError(validationFailure.ErrorMessage);
            }


            return validationResult;
        }
    }
}