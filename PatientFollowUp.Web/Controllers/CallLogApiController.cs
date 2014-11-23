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
    public class CallLogApiController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public CallLogApiController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("api/CallLogs/GetCallLogs/{followUpId}")]
        [HttpGet]
        public HttpResponseMessage GetCallLogs(int followUpId)
        {
            IEnumerable<FollowUpCallLog> callLogs = _repository.Find<FollowUpCallLog>(x => x.FollowUpId == followUpId);
            List<FollowUpCallLogViewModel> callLogViewModels =
                callLogs.Select(x => _mapper.Map<FollowUpCallLog, FollowUpCallLogViewModel>(x)).ToList();


            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content =
                    new ObjectContent<List<FollowUpCallLogViewModel>>(callLogViewModels,
                        new JsonMediaTypeFormatter()),
            };
        }

        [Route("api/CallLogs/CallLog")]
        [HttpPost]
        public HttpResponseMessage Post(CreateCallLogInputModel createCallLogInputModel)
        {
            var followUpCallLog = _mapper.Map<CreateCallLogInputModel, FollowUpCallLog>(createCallLogInputModel);

            followUpCallLog.FollowUpCallLogDate = DateTime.Now;

            _repository.Save(followUpCallLog);


            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}