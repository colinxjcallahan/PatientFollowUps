//using System;
//using System.Net;
//using System.Net.Http;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using PatientFollowUp.Data;
//using PatientFollowUp.Web.App_Data;
//using PatientFollowUp.Web.Controllers;

//namespace PatientFollowUp.Specs
//{
//    [TestClass]
//    public class when_changing_follow_up_date
//    {
//        private Mock<IDate> _date;
//        private FollowUpApiController _followUpApiController;
//        private int _followUpId;
//        private DateTime _newFollowUpDate;
//        private Mock<IRepository> _repository;
//        private FollowUp _followUpReturnedFromRepository;
//        private FollowUp _followUpPassedToSaveMethodOnRepository;

//        [TestInitialize]
//        public void Initialize()
//        {
//            _date = new Mock<IDate>();
//            _date.Setup(x => x.GetCurrentDate())
//                .Returns(new DateTime(2014, 1, 2));

//            _followUpId = 123;
//            _newFollowUpDate = new DateTime(2014, 1, 3);


//            _followUpReturnedFromRepository = new FollowUp
//            {
//                FollowUpDate = new DateTime(2014, 1,1)
//            };

//            _repository = new Mock<IRepository>();
//            _repository.Setup(x => x.GetById<FollowUp>(_followUpId))
//                .Returns(_followUpReturnedFromRepository);

//            _repository.Setup(x => x.Save(Moq.It.IsAny<FollowUp>()))
//                .Callback<FollowUp>(x => _followUpPassedToSaveMethodOnRepository = x);

//            _followUpApiController = new FollowUpApiController(_repository.Object, null, _date.Object, null);
//        }

//        [TestMethod]
//        public void it_should_update_the_follow_up_date()
//        {
//            HttpResponseMessage result = _followUpApiController.ChangeFollowUpDate(_followUpId, _newFollowUpDate);

//            Assert.AreEqual(_newFollowUpDate, _followUpPassedToSaveMethodOnRepository.FollowUpDate);
//        }

//        [TestMethod]
//        public void it_should_return_a_successful_result()
//        {
//            HttpResponseMessage result = _followUpApiController.ChangeFollowUpDate(_followUpId, _newFollowUpDate);

//            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
//        }
//    }
//}