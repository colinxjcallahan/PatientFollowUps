using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientFollowUp.Data;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.Controllers;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Specs
{
    [TestClass]
    public class when_adding_a_new_call_log
    {
        private CallLogApiController _callLogApiController;
        private Mock<IMapper> _mapper;
        private Mock<IRepository> _repository;
        private CreateCallLogInputModel _createCallLogInputModel;
        private FollowUpCallLog _followUpCallLogReturnedByMapper;
        private FollowUpCallLog _followUpCallLogPassedToRepository;

        [TestInitialize]
        public void Initialize()
        {
            _createCallLogInputModel = new CreateCallLogInputModel();
            _mapper = new Mock<IMapper>();
            _followUpCallLogReturnedByMapper = new FollowUpCallLog();
            _mapper.Setup(x => x.Map<CreateCallLogInputModel, FollowUpCallLog>(_createCallLogInputModel))
                .Returns(_followUpCallLogReturnedByMapper);


            _repository = new Mock<IRepository>();
            _repository.Setup(x => x.Save(It.IsAny<FollowUpCallLog>()))
                .Callback<FollowUpCallLog>(x => _followUpCallLogPassedToRepository = x);
            

            _callLogApiController = new CallLogApiController(_repository.Object, _mapper.Object);
        }

        [TestMethod]
        public void it_should_add_the_correct_call_log()
        {
            _callLogApiController.Post(_createCallLogInputModel);

            Assert.AreEqual(_followUpCallLogReturnedByMapper, _followUpCallLogPassedToRepository);
        }
    }
}