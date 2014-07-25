using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class when_requesting_the_patient_details_partial_view
    {
        private IEnumerable<Exam> _examsReturnedFromRepository;
        private int _followUpId;
        private FollowUpViewModel _followUpReturnedFromMapper;
        private FollowUpWithSynonymData _followUpReturnedFromRepository;
        private Mock<IMapper> _mapper;
        private PatientController _patientController;
        private Mock<IRepository> _repository;
        private ExamViewModel _examReturnedFromMapper;

        [TestInitialize]
        public void Initialize()
        {
            _followUpId = 567;

            _repository = new Mock<IRepository>();
            _followUpReturnedFromRepository = new FollowUpWithSynonymData
            {
                PatientMRN = "some patient mrn",
                Report = "some report info",
            };
            _repository.Setup(x => x.GetById<FollowUpWithSynonymData>(It.IsAny<int>()))
                .Returns(_followUpReturnedFromRepository);

            _examsReturnedFromRepository = new List<Exam>
            {
                new Exam(),
                new Exam(),
            };
            _repository.Setup(x => x.Find<Exam>(It.IsAny<Expression<Func<Exam, bool>>>()))
                .Returns(_examsReturnedFromRepository);

            _mapper = new Mock<IMapper>();
            _followUpReturnedFromMapper = new FollowUpViewModel();
            _mapper.Setup(x => x.Map<FollowUpWithSynonymData, FollowUpViewModel>(_followUpReturnedFromRepository))
                .Returns(_followUpReturnedFromMapper);

            _examReturnedFromMapper = new ExamViewModel();
            _mapper.Setup(x => x.Map<Exam, ExamViewModel>(It.IsAny<Exam>()))
                .Returns(_examReturnedFromMapper);


            _patientController = new PatientController(_repository.Object, _mapper.Object);
        }

        [TestMethod]
        public void it_should_display_the_patients_follow_up_info()
        {
            ActionResult result = _patientController.PatientDetails(_followUpId);

            FollowUpViewModel followUp = ((PatientDetailsViewModel) ((PartialViewResult) result).Model).FollowUp;

            Assert.AreEqual(_followUpReturnedFromMapper, followUp);
        }

        [TestMethod]
        public void it_should_display_the_patients_exam_history()
        {
            ActionResult result = _patientController.PatientDetails(_followUpId);

            List<ExamViewModel> exams = ((PatientDetailsViewModel) ((PartialViewResult) result).Model).Exams;

            Assert.AreEqual(_examReturnedFromMapper, exams.First());
        }
    }
}