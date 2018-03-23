using Autofac;
using System.Web.Mvc;
using Soccer.Web.Util;
using Soccer.Web.Modules;
using Autofac.Integration.Mvc;
using Soccer.Business.Modules;

namespace Soccer.Web
{
    public class AutofacConfig
    {
        public static void InitializeAutofac()
        {
            var builer = new ContainerBuilder();

            builer.RegisterControllers(typeof(MvcApplication).Assembly);

            builer.RegisterModule(new BusinessModule(ConstantStorage.ConnectionString));

            builer.RegisterModule(new WebModule());

            var container = builer.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}