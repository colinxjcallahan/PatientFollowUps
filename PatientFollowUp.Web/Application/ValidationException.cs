using System;
using PatientFollowUp.Web.App_Data;

namespace PatientFollowUp.Web.Application
{
    public class ValidationException : Exception
    {
        private ValidationResult _validationResult;

        public ValidationException(ValidationResult validationResult)
        {
            _validationResult = validationResult;
        }

        public ValidationResult ValidationResult
        {
            get { return _validationResult ?? (_validationResult = new ValidationResult()); }
        }
    }
}