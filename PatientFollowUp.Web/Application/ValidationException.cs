using System;
using PatientFollowUp.Web.App_Data;

namespace PatientFollowUp.Web.Application
{
    public class ValidationException : Exception
    {
        public ValidationResult ValidationResult { get; set; }
    }
}