using System.Web.Mvc;
using PatientFollowUp.Web.Application;

namespace PatientFollowUp.Web.Controllers
{
    [GlobalExceptionFilter]
    public class FollowUpController : Controller
    {
        public ActionResult OpenFollowUps()
        {
            return View();
        }
    }
}