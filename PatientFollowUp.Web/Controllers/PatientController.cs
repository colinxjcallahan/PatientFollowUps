using System.Linq;
using System.Web.Mvc;
using PatientFollowUp.Data;
using PatientFollowUp.Web.App_Data;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public PatientController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult PatientDetails(int followUpId)
        {
            var followUp = _repository.GetById<FollowUpWithSynonymData>(followUpId);
            var followUpViewModel = _mapper.Map<FollowUpWithSynonymData, FollowUpViewModel>(followUp);

            var exams = _repository.Find<Exam>(x => x.PatientMRN == followUp.PatientMRN && x.CompletionDate > followUp.FollowUpDate);
            var examViewModels = exams.Select(x => _mapper.Map<Exam, ExamViewModel>(x));

            var patientDetailsViewModel = new PatientDetailsViewModel
            {
                FollowUp = followUpViewModel,
                Exams = examViewModels.ToList(),
            };

            return PartialView(patientDetailsViewModel);
        }
    }
}