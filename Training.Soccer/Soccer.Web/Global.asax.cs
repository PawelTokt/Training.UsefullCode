using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace Soccer.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.InitializeAutofac();
            AutomapperConfig.InitializeAutoMapper();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}