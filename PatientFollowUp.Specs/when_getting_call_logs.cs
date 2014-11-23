using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientFollowUp.Data;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.Controllers;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Specs
{
    [TestClass]
    public class when_getting_call_logs
    {
        private CallLogApiController _callLogApiController;
        private IEnumerable<FollowUpCallLog> _callLogsReturnedByRepository;
        private int _followUpId;
        private Mock<IRepository> _repository;
        private Mock<IMapper> _mapper;

        [TestInitialize]
        public void Initialize()
        {
            _followUpId = 567;

            _repository = new Mock<IRepository>();

            _callLogsReturnedByRepository = new List<FollowUpCallLog>
            {
                new FollowUpCallLog(),
                new FollowUpCallLog(),
                new FollowUpCallLog(),
            };
            _repository.Setup(x => x.Find(It.IsAny<Expression<Func<FollowUpCallLog, bool>>>()))
                .Returns(_callLogsReturnedByRepository);

            _mapper = new Mock<IMapper>();
            _mapper.Setup(x => x.Map<FollowUpCallLog, FollowUpCallLogViewModel>(It.IsAny<FollowUpCallLog>()))
                .Returns(new FollowUpCallLogViewModel());

            _callLogApiController = new CallLogApiController(_repository.Object, _mapper.Object);
        }

        [TestMethod]
        public void it_should_return_the_correct_list_of_call_logs()
        {
            HttpResponseMessage result = _callLogApiController.GetCallLogs(_followUpId);

            var callLogViewModels =
                ((List<FollowUpCallLogViewModel>) ((ObjectContent<List<FollowUpCallLogViewModel>>) (result.Content)).Value);

            Assert.AreEqual(_callLogsReturnedByRepository.Count(), callLogViewModels.Count);
        }
    }
}