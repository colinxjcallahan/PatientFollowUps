using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientFollowUp.Data;
using PatientFollowUp.Web.App_Data;
using PatientFollowUp.Web.Controllers;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Specs
{
    [TestClass]
    public class when_saving_followup_details
    {
        private Mock<IDate> _date;
        private FollowUpController _followUpController;
        private Mock<IMapper> _mapper;
        private Mock<IRepository> _repository;
        private SaveFollowUpUpdatesInputModel _saveFollowUpUpdatesInputModel;
        private FollowUp _followUpReturnedFromMapper;
        private FollowUp _followUpPassedToRepository;

        [TestInitialize]
        public void Initialize()
        {
            _saveFollowUpUpdatesInputModel = new SaveFollowUpUpdatesInputModel
            {
                Comments = "some comments",
                FollowUpExamIds = new List<Int64>
                {
                    112233,
                    223344,
                },
                NoRelevantFollowupFound = true,
            };

            _mapper = new Mock<IMapper>();
            _followUpReturnedFromMapper = new FollowUp
            {
                 Comments = "some comments",
            };
            _mapper.Setup(x => x.Map<SaveFollowUpUpdatesInputModel, FollowUp>(_saveFollowUpUpdatesInputModel))
                .Returns(_followUpReturnedFromMapper);
            
            
            _repository = new Mock<IRepository>();
            
            _repository.Setup(x => x.Save<FollowUp>(_followUpReturnedFromMapper))
                .Callback<FollowUp>(x => _followUpPassedToRepository = x);

            _followUpController = new FollowUpController(_repository.Object, _mapper.Object, null);
        }

        [TestMethod]
        public void it_should_save_the_followup_details()
        {
            ActionResult result = _followUpController.SaveFollowUpUpdates(_saveFollowUpUpdatesInputModel);
            Assert.AreEqual(_followUpReturnedFromMapper.Comments, _followUpPassedToRepository.Comments);
        }

        [TestMethod]
        public void it_should_save_the_followup_exams()
        {
            ActionResult result = _followUpController.SaveFollowUpUpdates(_saveFollowUpUpdatesInputModel);

            Assert.AreEqual(_saveFollowUpUpdatesInputModel.FollowUpExamIds.First(), _followUpPassedToRepository.FollowUpExams.First().FollowUpExamId);
        }
    }
}