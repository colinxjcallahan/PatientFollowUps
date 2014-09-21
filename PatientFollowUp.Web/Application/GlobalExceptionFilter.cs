using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;
using log4net;

namespace PatientFollowUp.Web.Application
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var ex = actionExecutedContext.Exception;

            LogThis(actionExecutedContext.Exception);


            if (actionExecutedContext.Exception is ValidationException)
            {
                var exception = actionExecutedContext.Exception as ValidationException;
                var failureResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);

                failureResponseMessage.Content = new ObjectContent<ValidationResult>(exception.ValidationResult, 
                    new JsonMediaTypeFormatter());

                actionExecutedContext.Response = failureResponseMessage;
            }
        }

        public void LogThis(Exception exception)
        {
            log4net.Config.BasicConfigurator.Configure();
            ILog log = log4net.LogManager.GetLogger(typeof(GlobalExceptionFilter));

            log.Error("Patient FollowUps Error", exception);
        }
    }
}