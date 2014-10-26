using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using PatientFollowUp.Data;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Web.Controllers
{
    public class CallLogApiController
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public CallLogApiController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public HttpResponseMessage GetCallLogs(int followUpId)
        {
            IEnumerable<CallLog> callLogs = _repository.Find<CallLog>(x => x.FollowUpId == followUpId);
            List<CallLogViewModel> callLogViewModels =
                callLogs.Select(x => _mapper.Map<CallLog, CallLogViewModel>(x)).ToList();


            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content =
                    new ObjectContent<List<CallLogViewModel>>(callLogViewModels,
                        new JsonMediaTypeFormatter()),
            };
        }
    }
}