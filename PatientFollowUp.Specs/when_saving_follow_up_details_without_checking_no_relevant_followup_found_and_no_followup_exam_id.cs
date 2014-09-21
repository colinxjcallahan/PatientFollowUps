using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.Controllers;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Specs
{
    [TestClass]
    public class when_saving_follow_up_details_without_checking_no_relevant_followup_found_and_no_followup_exam_id
    {
        private SaveFollowUpUpdatesInputModel _saveFollowUpUpdatesInputModel;
        private SaveFollowUpUpdatesInputModelValidator _saveFollowUpUpdatesInputModelValidator;

        [TestInitialize]
        public void Initialize()
        {
            _saveFollowUpUpdatesInputModel = new SaveFollowUpUpdatesInputModel
            {
                FollowUpExamId = 0,
                NoRelevantFollowUpFound = false,
            };
            _saveFollowUpUpdatesInputModelValidator = new SaveFollowUpUpdatesInputModelValidator();
        }

        [TestMethod]
        public void it_should_not_be_valid()
        {
            var validationResult = _saveFollowUpUpdatesInputModelValidator.Validate(_saveFollowUpUpdatesInputModel);
            Assert.IsFalse(validationResult.IsValid);
        }

        [TestMethod]
        public void it_should_return_an_error_message()
        {
            var validationResult = _saveFollowUpUpdatesInputModelValidator.Validate(_saveFollowUpUpdatesInputModel);
            Assert.AreEqual(validationResult.Errors.First(), "Either select an exam ID or select 'No Relevant Followup' and select a Reason");
        }
    }
}