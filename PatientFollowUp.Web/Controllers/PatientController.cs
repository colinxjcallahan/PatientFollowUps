using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PatientFollowUp.Data;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web.Controllers
{
    [GlobalExceptionFilter]
    public class PatientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public PatientController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult PatientDetails(int followUpId)
        {
            var followUp = _repository.GetById<FollowUpWithSynonymData>(followUpId);
            FollowUpViewModel followUpViewModel = _mapper.Map<FollowUpWithSynonymData, FollowUpViewModel>(followUp);

            IEnumerable<Exam> exams =
                _repository.Find<Exam>(
                    x => x.PatientMRN == followUp.PatientMRN && x.CompletionDate > followUp.FollowUpDate);
            IEnumerable<ExamViewModel> examViewModels = exams.Select(x => _mapper.Map<Exam, ExamViewModel>(x));

            List<FollowUpClosedReason> followUpClosedReasons = _repository.GetAll<FollowUpClosedReason>().ToList();
            IEnumerable<FollowUpClosedReasonViewModel> followUpClosedReasonViewModels =
                followUpClosedReasons.Select(x => _mapper.Map<FollowUpClosedReason, FollowUpClosedReasonViewModel>(x));

            var patientDetailsViewModel = new PatientDetailsViewModel
            {
                FollowUp = followUpViewModel,
                Exams = examViewModels.ToList(),
                FollowUpClosedReasons = followUpClosedReasonViewModels.ToList(),
            };

            return PartialView(patientDetailsViewModel);
        }
    }
}