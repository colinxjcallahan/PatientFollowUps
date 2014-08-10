using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientFollowUp.Data;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.App_Data;
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


        [Route("api/FollowUpApi/SaveFollowUpUpdates")]
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

            existingFollowUp.StatusID = (int) FollowUpStatusEnum.Closed;
            existingFollowUp.Comments = saveFollowUpUpdatesInputModel.Comments;
            existingFollowUp.NoRelevantFollowUpFound = saveFollowUpUpdatesInputModel.NoRelevantFollowUpFound;
            existingFollowUp.FollowUpExamId = saveFollowUpUpdatesInputModel.FollowUpExamId;
            existingFollowUp.FollowUpClosedReasonId = saveFollowUpUpdatesInputModel.FollowUpClosedReasonId;

            _repository.Save(existingFollowUp);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("api/FollowUpApi/ChangeFollowUpDate")]
        public HttpResponseMessage ChangeFollowUpDate(int followUpId, DateTime newFollowUpDate)
        {
            if (newFollowUpDate < _date.GetCurrentDate())
            {
                var validationResult = new ValidationResult();
                validationResult.AddError("FollowUpId", "Follow Up Date must be later than today");
                var validationException = new ValidationException(validationResult);
                throw validationException;
            }

            var followUpToUpdate = _repository.GetById<FollowUp>(followUpId);
            followUpToUpdate.FollowUpDate = newFollowUpDate;

            _repository.Save(followUpToUpdate);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}