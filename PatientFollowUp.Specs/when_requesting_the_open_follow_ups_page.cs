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
    public class when_requesting_the_open_follow_ups_page
    {
        private Mock<IDate> _date;
        private FollowUpController _followUpController;
        private IQueryable<FollowUpWithSynonymData> _followUpsReturnedFromRepository;
        private Mock<IMapper> _mapper;
        private Mock<IRepository> _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new Mock<IRepository>();

            _date = new Mock<IDate>();
            _date.Setup(x => x.GetCurrentDate())
                .Returns(new DateTime(2014, 1, 1));

            _followUpsReturnedFromRepository =
                new EnumerableQuery<FollowUpWithSynonymData>(new List<FollowUpWithSynonymData>
                {
                    new FollowUpWithSynonymData
                    {
                        FollowUpStatus = "Open",
                        FollowUpdate = new DateTime(2014, 1, 2),
                    },

                    new FollowUpWithSynonymData
                    {
                        FollowUpStatus = "Open",
                        FollowUpdate = new DateTime(2013, 12, 31),
                    },

                    new FollowUpWithSynonymData
                    {
                        FollowUpStatus = "Closed",
                        FollowUpdate = new DateTime(2014, 1, 2),
                    },


                });
            _repository.Setup(x => x.GetAll<FollowUpWithSynonymData>())
                .Returns(_followUpsReturnedFromRepository);


            _mapper = new Mock<IMapper>();
            _mapper.Setup(x => x.Map<FollowUpWithSynonymData, FollowUpViewModel>(It.IsAny<FollowUpWithSynonymData>()))
                .Returns(new FollowUpViewModel());

            _followUpController = new FollowUpController(_repository.Object, _mapper.Object, _date.Object);
        }


        [TestMethod]
        public void it_should_return_a_list_of_follow_ups_that_are_open_and_past_the_follow_up_date()
        {
            ActionResult result = _followUpController.OpenFollowUps();
            List<FollowUpViewModel> followUps = ((OpenFollowUpsViewModel) ((ViewResult) result).Model).FollowUps;

            Assert.AreEqual(1, followUps.Count);
        }
    }
}