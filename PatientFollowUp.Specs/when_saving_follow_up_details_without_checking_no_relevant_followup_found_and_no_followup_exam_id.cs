using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientFollowUp.Web.Controllers;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Specs
{
    [TestClass]
    public class when_saving_follow_up_details_without_checking_no_relevant_followup_found_and_no_followup_exam_id
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
                NoRelevantFollowUpFound = false,
                FollowUpId = 890,
            };


            _followUpController = new FollowUpController(null, null, null, null);
        }

        [TestMethod]
        public void it_should_return_an_error()
        {
            HttpStatusCode result = _followUpController.SaveFollowUpUpdates(_saveFollowUpUpdatesInputModel).StatusCode;

            Assert.AreEqual(HttpStatusCode.BadRequest, result);
        }

        [TestMethod]
        public void it_should_return_an_error_message()
        {
            HttpResponseMessage result = _followUpController.SaveFollowUpUpdates(_saveFollowUpUpdatesInputModel);

            Assert.AreEqual("A followup exam must be selected when choosing 'No Relevant Followup Found' is not selected", result.ReasonPhrase);
        }
    }
}