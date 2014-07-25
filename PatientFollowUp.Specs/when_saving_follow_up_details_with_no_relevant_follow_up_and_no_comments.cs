using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientFollowUp.Web.Controllers;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Specs
{
    [TestClass]
    public class when_saving_follow_up_details_with_no_relevant_follow_up_and_no_comments
    {
        private FollowUpController _followUpController;
        private SaveFollowUpUpdatesInputModel _saveFollowUpUpdatesInputModel;

        [TestInitialize]
        public void Initialize()
        {
            _saveFollowUpUpdatesInputModel = new SaveFollowUpUpdatesInputModel
            {
                Comments = null,
                FollowUpExamId = 0,
                NoRelevantFollowUpFound = true,
                FollowUpId = 890,
            };


            _followUpController = new FollowUpController(null, null, null, null);
        }

        [TestMethod]
        public void it_should_return_an_error()
        {
            var result = ((HttpResponseMessage)_followUpController.SaveFollowUpUpdates(_saveFollowUpUpdatesInputModel)).StatusCode;

            Assert.AreEqual(HttpStatusCode.BadRequest, result);
        }

        [TestMethod]
        public void it_should_return_an_error_message()
        {
            var result = ((HttpResponseMessage)_followUpController.SaveFollowUpUpdates(_saveFollowUpUpdatesInputModel));

            Assert.AreEqual("Comments must be provided when choosing 'No Relevant Followup Found'", result.ReasonPhrase);
        }
    }
}