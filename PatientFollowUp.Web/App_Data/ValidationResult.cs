using System.Collections.Generic;

namespace PatientFollowUp.Web.App_Data
{
    public class ValidationResult
    {
        private readonly List<string> _errors;

        public ValidationResult()
        {
            _errors = new List<string>();
        }

        public bool IsValid { get; set; }

        public IEnumerable<string> Errors
        {
            get { return _errors; }
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}