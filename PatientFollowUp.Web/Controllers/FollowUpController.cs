using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PatientFollowUp.Data;
using PatientFollowUp.Web.App_Data;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web.Controllers
{
    public class FollowUpController : Controller
    {
        private readonly IDate _date;
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public FollowUpController(IRepository repository, IMapper mapper, IDate date)
        {
            _repository = repository;
            _mapper = mapper;
            _date = date;
        }

        public ActionResult OpenFollowUps()
        {
            DateTime currentDate = _date.GetCurrentDate();

            List<FollowUpWithSynonymData> followUps =
                _repository.GetAll<FollowUpWithSynonymData>()
                    .Where(x => x.FollowUpStatus == "Open" && x.FollowUpdate < currentDate)
                    .ToList();


            var viewModel = new OpenFollowUpsViewModel
            {
                FollowUps = followUps.Select(x => _mapper.Map<FollowUpWithSynonymData, FollowUpViewModel>(x)).ToList(),
            };

            return View(viewModel);
        }

        public ActionResult SaveFollowUpUpdates(SaveFollowUpUpdatesInputModel saveFollowUpUpdatesInputModel)
        {
            var existingFollowUp = _repository.GetById<FollowUp>(saveFollowUpUpdatesInputModel.FollowUpId);
            existingFollowUp.Comments = saveFollowUpUpdatesInputModel.Comments;
            existingFollowUp.NoRelevantFollowUpFound = saveFollowUpUpdatesInputModel.NoRelevantFollowupFound;

            if (saveFollowUpUpdatesInputModel.FollowUpExamIds != null)
            {
                foreach (var followUpExamId in saveFollowUpUpdatesInputModel.FollowUpExamIds)
                {
                    existingFollowUp.FollowUpExams.Add(new FollowUpExam
                    {
                        FollowUpExamId = followUpExamId,
                        FollowUp = existingFollowUp,
                    });
                }
            }

            _repository.Save<FollowUp>(existingFollowUp);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}