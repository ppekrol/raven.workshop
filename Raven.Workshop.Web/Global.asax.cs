using Raven.Client;
using Raven.Workshop.Web.Indexes;
using Raven.Workshop.Web.Transformers;

namespace Raven.Workshop.Web
{
    using System;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Raven.Client.Document;
    using Raven.Client.Extensions;
    using Raven.Client.MvcIntegration;
    using Raven.Workshop.Web.Helpers;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            try
            {
                InitializeDocumentStore();
                InitializeRavenProfiler();
                DeployIndexes(DocumentStoreHolder.Store);
				DeployTransformers(DocumentStoreHolder.Store);

                WorkshopHelper.IsConnected = true;
            }
            catch (Exception)
            {
            }
        }

	    private void DeployTransformers(IDocumentStore store)
	    {
		    new CompaniesWithEmployees().Execute(store);
	    }

	    private void DeployIndexes(IDocumentStore store)
	    {
			new CompanyEmployees().Execute(store);
			new EmployeesByFirstNameCount().Execute(store);
			new CompanyByName().Execute(store);
	    }

	    private static void InitializeDocumentStore()
        {
            var databaseName = "tgd.net.workshop";

            DocumentStoreHolder.Store =
                new DocumentStore
                    {
                        Url = "http://localhost:8080", 
                        DefaultDatabase = databaseName
                    }.Initialize();

            DocumentStoreHolder.Store.DatabaseCommands.EnsureDatabaseExists(databaseName);
        }

        private static void InitializeRavenProfiler()
		{
			if (DocumentStoreHolder.Store != null)
				RavenProfiler.InitializeFor(DocumentStoreHolder.Store);
		}
    }
}