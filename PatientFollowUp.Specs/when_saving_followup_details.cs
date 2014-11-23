using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientFollowUp.Data;
using PatientFollowUp.Web.Controllers;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Specs
{
    [TestClass]
    public class when_saving_followup_details
    {
        private FollowUpApiController _followUpController;
        private FollowUp _followUpPassedToRepository;
        private FollowUp _followUpReturnedByRepository;
        private Mock<IRepository> _repository;
        private SaveFollowUpUpdatesInputModel _saveFollowUpUpdatesInputModel;

        [TestInitialize]
        public void Initialize()
        {
            _saveFollowUpUpdatesInputModel = new SaveFollowUpUpdatesInputModel
            {
                Comments = "some new comments",
                FollowUpExamId = 89098,
                NoRelevantFollowUpFound = false,
                FollowUpId = 890,
            };

            _repository = new Mock<IRepository>();

            _followUpReturnedByRepository = new FollowUp
            {
                Comments = "",
                FollowUpExamCptCode = "",
                NoRelevantFollowUpFound = false,
                FollowUpID = 890,
            };
            _repository.Setup(x => x.GetById<FollowUp>(_saveFollowUpUpdatesInputModel.FollowUpId))
                .Returns(_followUpReturnedByRepository);

            _repository.Setup(x => x.Save(It.IsAny<FollowUp>()))
                .Callback<FollowUp>(x => _followUpPassedToRepository = x);

            _followUpController = new FollowUpApiController(_repository.Object, null, null, null);
        }

        [TestMethod]
        public void it_should_save_the_followup_details()
        {
            HttpResponseMessage result = _followUpController.SaveFollowUpUpdates(_saveFollowUpUpdatesInputModel);
            Assert.AreEqual(_saveFollowUpUpdatesInputModel.Comments, _followUpPassedToRepository.Comments);
        }
    }
}