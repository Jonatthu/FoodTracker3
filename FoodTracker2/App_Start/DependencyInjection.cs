using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

namespace FoodTracker3.App_Start
{
    public class DependencyInjection
    {
        public static void Initialize()
        {
            var container = new Container();
            //container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            //container.Register<PrescriptionUnitOfWork, PrescriptionUnitOfWork>(Lifestyle.Scoped);
            //container.Register<GenericUnitOfWork, GenericUnitOfWork>
            container.RegisterMvcControllers();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}