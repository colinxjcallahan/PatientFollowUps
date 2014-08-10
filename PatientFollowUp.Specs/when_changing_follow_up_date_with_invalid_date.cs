using System;
using System.Linq;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.App_Data;
using PatientFollowUp.Web.Controllers;

namespace PatientFollowUp.Specs
{
    [TestClass]
    public class when_changing_follow_up_date_with_invalid_date
    {
        private Mock<IDate> _date;
        private Exception _exception;
        private FollowUpApiController _followUpApiController;
        private int _followUpId;
        private DateTime _newFollowUpDate;

        [TestInitialize]
        public void Initialize()
        {
            _date = new Mock<IDate>();
            _date.Setup(x => x.GetCurrentDate())
                .Returns(new DateTime(2014, 1, 2));

            _followUpId = 123;
            _newFollowUpDate = new DateTime(2014, 1, 1);

            _followUpApiController = new FollowUpApiController(null, null, _date.Object, null);
        }

        [TestMethod]
        public void it_should_throw_a_validation_exception()
        {
            try
            {
                HttpResponseMessage result = _followUpApiController.ChangeFollowUpDate(_followUpId, _newFollowUpDate);
            }
            catch (Exception exception)
            {
                _exception = exception;
            }

            Assert.IsInstanceOfType(_exception, typeof (ValidationException));
        }

        [TestMethod]
        public void it_should_have_the_correct_error_message()
        {
            try
            {
                HttpResponseMessage result = _followUpApiController.ChangeFollowUpDate(_followUpId, _newFollowUpDate);
            }
            catch (Exception exception)
            {
                _exception = exception;
            }

            string errorMessage = ((ValidationException) _exception).ValidationResult.Errors.First().Message;
            Assert.AreEqual("Follow Up Date must be later than today", errorMessage);
        }
    }
}