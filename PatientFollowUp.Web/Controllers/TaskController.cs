using System.Web.Mvc;

namespace PatientFollowUp.Web.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult Tasks()
        {
            return View();
        }
    }
}