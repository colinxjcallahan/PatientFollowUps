//using System.Collections.Generic;
//using System.Net;
//using System.Net.Http;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using PatientFollowUp.Web.App_Data;
//using PatientFollowUp.Web.Controllers;
//using PatientFollowUp.Web.Models;

//namespace PatientFollowUp.Specs
//{
//    [TestClass]
//    public class when_saving_followup_details_with_invalid_data
//    {
//        private FollowUpController _followUpController;
//        private SaveFollowUpUpdatesInputModel _saveFollowUpUpdatesInputModel;
//        private ValidationResult _validationResultReturnedByValidator;
//        private Mock<IValidator> _validator;

//        [TestInitialize]
//        public void Initialize()
//        {
//            _saveFollowUpUpdatesInputModel = new SaveFollowUpUpdatesInputModel();

//            _validator = new Mock<IValidator>();
//            _validationResultReturnedByValidator = new ValidationResult
//            {
//                IsValid = false,
//            };
//            _validationResultReturnedByValidator.AddError(
//                "Some Error");
//            _validator.Setup(x => x.Validate(_saveFollowUpUpdatesInputModel))
//                .Returns(_validationResultReturnedByValidator);

//            _followUpController = new FollowUpController(null, null, null, _validator.Object);
//        }

//        [TestMethod]
//        public void it_should_return_an_error()
//        {
//            HttpResponseMessage result = _followUpController.SaveFollowUpUpdates(_saveFollowUpUpdatesInputModel);
//            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
//        }        
//    }
//}