using System.Web.Mvc;
using Microsoft.Practices.Unity;
using PatientFollowUp.Data;
using PatientFollowUp.Web.App_Data;
using PatientFollowUp.Web.Models;
using Unity.Mvc4;

namespace PatientFollowUp.Web
{
    public static class UnityConfig
    {
        public static IUnityContainer Initialise()
        {
            IUnityContainer container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IMapper, AutoMapperMapper>();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IDate, Date>();

            return container;
        }
    }
}