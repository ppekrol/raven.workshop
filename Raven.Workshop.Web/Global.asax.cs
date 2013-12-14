using Raven.Client.Document;
using Raven.Client.Extensions;

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

	        var databaseName = "tgd.net.workshop";

	        DocumentStoreHolder.Store = new DocumentStore()
		        {
			        Url = "http://localhost:8080",
			        DefaultDatabase = databaseName
		        }.Initialize();

			DocumentStoreHolder.Store.DatabaseCommands.EnsureDatabaseExists(databaseName);

	        InitializeRavenProfiler();
        }

		private void InitializeRavenProfiler()
		{
			if (DocumentStoreHolder.Store != null)
				Client.MvcIntegration.RavenProfiler.InitializeFor(DocumentStoreHolder.Store);
		}
    }
}