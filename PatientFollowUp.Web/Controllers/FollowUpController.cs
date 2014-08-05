using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private readonly IValidator _validator;

        public FollowUpController(IRepository repository, IMapper mapper, IDate date, IValidator validator)
        {
            _repository = repository;
            _mapper = mapper;
            _date = date;
            _validator = validator;
        }

        public ActionResult GetOpenFollowUps()
        {
            DateTime currentDate = _date.GetCurrentDate();

            List<FollowUpWithSynonymData> followUps =
                _repository.GetAll<FollowUpWithSynonymData>()
                    .Where(x => x.FollowUpStatus == "Open" && x.FollowUpDate < currentDate)
                    .ToList();


            var viewModel = new OpenFollowUpsViewModel
            {
                FollowUps = followUps.Select(x => _mapper.Map<FollowUpWithSynonymData, FollowUpViewModel>(x)).ToList(),
            };

            return PartialView(viewModel);
        }

        public ActionResult OpenFollowUps()
        {
            return View();
        }
    }
}