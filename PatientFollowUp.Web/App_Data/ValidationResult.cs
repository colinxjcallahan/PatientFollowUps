using System.Collections.Generic;

namespace PatientFollowUp.Web.App_Data
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors = new List<ValidationError>();

        public List<ValidationError> Errors
        {
            get { return _errors; }
        }

        public bool IsValid { get; set; }

        public void AddError(string property, string error)
        {
            _errors.Add(new ValidationError
            {
                Property = property,
                Message = error,
            });
        }
    }
}