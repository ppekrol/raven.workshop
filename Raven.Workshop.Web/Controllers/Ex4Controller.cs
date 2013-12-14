using Raven.Workshop.Web.Indexes;

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
                .Query<EmployeesByFirstNameCount.Result, EmployeesByFirstNameCount>()
                .ToList();

            return View(results);
        }
    }
}