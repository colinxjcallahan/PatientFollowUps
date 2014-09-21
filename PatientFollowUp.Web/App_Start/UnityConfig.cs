using System.Web.Mvc;
using Microsoft.Practices.Unity;
using System.Web.Http;
using PatientFollowUp.Data;
using PatientFollowUp.Web.Application;
using PatientFollowUp.Web.Models;
using Unity.WebApi;

namespace PatientFollowUp.Web
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            IUnityContainer container = BuildUnityContainer();

            DependencyResolver.SetResolver(new Unity.Mvc4.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            return container;
        }


        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IMapper, AutoMapperMapper>();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IDate, Date>();
            container.RegisterType<IValidator, SaveFollowUpUpdatesInputModelValidator>();

            return container;
        }
    }
}