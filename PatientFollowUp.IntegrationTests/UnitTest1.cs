using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientFollowUp.Data;
using PatientFollowUp.Web;
using PatientFollowUp.Web.App_Data;
using PatientFollowUp.Web.Controllers;

namespace PatientFollowUp.IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        private IMapper _mapper;
        private IRepository _repository;
        private IValidator _validator;

        [TestMethod]
        public void TestMethod1()
        {


            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutomapperConfig.RegisterMappings();
            UnityConfig.RegisterComponents();

            var container = UnityConfig.RegisterComponents();

            _repository = container.Resolve<IRepository>();

            var followUpController = new FollowUpController(_repository, _mapper, new Date(), _validator);

            var result = followUpController.OpenFollowUps();
        }
    }
}