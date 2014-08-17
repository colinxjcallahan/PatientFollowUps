using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;
using PatientFollowUp.Web.App_Data;

namespace PatientFollowUp.Web.Application
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var ex = actionExecutedContext.Exception;
            if (actionExecutedContext.Exception is ValidationException)
            {
                var exception = actionExecutedContext.Exception as ValidationException;
                var failureResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);

                failureResponseMessage.Content = new ObjectContent<ValidationResult>(exception.ValidationResult, 
                    new JsonMediaTypeFormatter());

                actionExecutedContext.Response = failureResponseMessage;
            }
        }
    }
}