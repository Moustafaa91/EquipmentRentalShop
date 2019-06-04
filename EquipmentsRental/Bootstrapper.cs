using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using BusinessLogic.Rental;
using EquipmentsRental.Controllers;
using Utilities.Log;
using Utilities.Language;

namespace EquipmentsRental
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IRentalOperations, RentalOperations>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<ILanguageMang, LanguageMang>();
            container.RegisterType<IController, HomeController>("Home");

            return container;
        }
    }
}