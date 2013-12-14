namespace Raven.Workshop.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Raven.Workshop.Web.Helpers;

    public class Ex4Controller : RavenController
    {
        public ActionResult Index()
        {
            WorkshopHelper.DeployData(RavenSession);

            var results =
                RavenSession
                .Query<IndexConfig.EmployeesByFirstNameCount.Result, IndexConfig.EmployeesByFirstNameCount>()
                .ToList();

            return View(results);
        }
    }
}