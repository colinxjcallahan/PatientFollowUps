using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using PatientFollowUp.Data;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web.Controllers
{
    [GlobalExceptionFilter]
    public class FollowUpApiController : ApiController
    {
        private readonly IDate _date;
        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        private readonly IValidator _validator;

        public FollowUpApiController(IRepository repository, IMapper mapper, IDate date, IValidator validator)
        {
            _repository = repository;
            _mapper = mapper;
            _date = date;
            _validator = validator;
        }

        [Route("api/FollowUps/GetOpenFollowUps")]
        [HttpGet]
        public HttpResponseMessage GetOpenFollowUps()
        {
            DateTime currentDate = _date.GetCurrentDate();

            List<FollowUpWithSynonymData> followUps =
                _repository.GetAll<FollowUpWithSynonymData>()
                    .Where(x => x.FollowUpStatus == "Open" && x.FollowUpDate < currentDate)
                    .ToList();



            var followUpViewModels =
                followUps.Select(x => _mapper.Map<FollowUpWithSynonymData, FollowUpViewModel>(x)).ToList();



            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content =
                    new ObjectContent<List<FollowUpViewModel>>(followUpViewModels,
                        new JsonMediaTypeFormatter()),
                        
            };
        }


        [Route("api/FollowUps/SaveFollowUpUpdates")]
        [HttpPost]
        public HttpResponseMessage SaveFollowUpUpdates(SaveFollowUpUpdatesInputModel saveFollowUpUpdatesInputModel)
        {
            ValidationResult validationResult = _validator.Validate(saveFollowUpUpdatesInputModel);
            if (!validationResult.IsValid)
            {
                var validationException = new ValidationException(validationResult);

                throw validationException;
            }

            var existingFollowUp = _repository.GetById<FollowUp>(saveFollowUpUpdatesInputModel.FollowUpId);

            if (saveFollowUpUpdatesInputModel.NewFollowUpDate == DateTime.MinValue)
            {
                existingFollowUp.StatusID = (int) FollowUpStatusEnum.Closed;
            }

            existingFollowUp.Comments = saveFollowUpUpdatesInputModel.Comments;
            existingFollowUp.NoRelevantFollowUpFound = saveFollowUpUpdatesInputModel.NoRelevantFollowUpFound;
            existingFollowUp.FollowUpExamId = saveFollowUpUpdatesInputModel.FollowUpExamId;
            existingFollowUp.FollowUpClosedReasonId = saveFollowUpUpdatesInputModel.FollowUpClosedReasonId;

            if (!(saveFollowUpUpdatesInputModel.NewFollowUpDate == DateTime.MinValue))
            {
                existingFollowUp.FollowUpDate = saveFollowUpUpdatesInputModel.NewFollowUpDate;
            }

            _repository.Save(existingFollowUp);


            var followUpHistory = _mapper.Map<FollowUp, FollowUpHistory>(existingFollowUp);
            _repository.Save(followUpHistory);


            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("api/FollowUps/FollowUpHistory/{followUpID}")]
        [HttpGet]
        public HttpResponseMessage FollowUpHistory(int followUpID)
        {
            var followUpHistoryItems = _repository.Find<FollowUpHistory>(x => x.FollowUpID == followUpID);

            var followUpHistoryViewModels =
                followUpHistoryItems.Select(x => _mapper.Map<FollowUpHistory, FollowUpHistoryViewModel>(x)).ToList();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content =
                    new ObjectContent<List<FollowUpHistoryViewModel>>(followUpHistoryViewModels,
                        new JsonMediaTypeFormatter()),

            };

        }
    }
}