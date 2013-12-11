using Raven.Client.Document;

namespace Raven.Workshop.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

	        DocumentStoreHolder.Store = new DocumentStore()
		        {
			        Url = "http://localhost:8080",
			        DefaultDatabase = "tgd.net.workshop"
		        }.Initialize();

	        InitializeRavenProfiler();
        }

		private void InitializeRavenProfiler()
		{
			Raven.Client.MvcIntegration.RavenProfiler.InitializeFor(DocumentStoreHolder.Store);
		}
    }
}