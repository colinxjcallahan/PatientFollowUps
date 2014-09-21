using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.Models;

namespace PatientFollowUp.Specs
{
    [TestClass]
    public class when_saving_follow_up_details_with_no_relevant_follow_up_and_no_reason
    {
        private SaveFollowUpUpdatesInputModel _saveFollowUpUpdatesInputModel;
        private SaveFollowUpUpdatesInputModelValidator _saveFollowUpUpdatesInputModelValidator;

        [TestInitialize]
        public void Initialize()
        {
            _saveFollowUpUpdatesInputModel = new SaveFollowUpUpdatesInputModel
            {
                NoRelevantFollowUpFound = true,
                FollowUpClosedReasonId = 0,
            };
            _saveFollowUpUpdatesInputModelValidator = new SaveFollowUpUpdatesInputModelValidator();
        }

        [TestMethod]
        public void it_should_not_be_valid()
        {
            ValidationResult validationResult =
                _saveFollowUpUpdatesInputModelValidator.Validate(_saveFollowUpUpdatesInputModel);
            Assert.IsFalse(validationResult.IsValid);
        }

        [TestMethod]
        public void it_should_return_an_error_message()
        {
            ValidationResult validationResult =
                _saveFollowUpUpdatesInputModelValidator.Validate(_saveFollowUpUpdatesInputModel);
            Assert.AreEqual(validationResult.Errors.First(),
                "You must select a reason when closing with no relevant exam found");
        }
    }
}