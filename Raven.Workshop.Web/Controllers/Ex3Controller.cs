using Raven.Workshop.Web.Indexes;

namespace Raven.Workshop.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Raven.Workshop.Web.Helpers;
    using Raven.Workshop.Web.Models;

    public class Ex3Controller : RavenController
    {
        public ActionResult Index()
        {
            WorkshopHelper.DeployData(RavenSession);

            var companies = RavenSession
                .Advanced
                .LuceneQuery<Company, CompanyEmployees>()
                .WhereStartsWith("FirstName", "J")
                .ToList();

            return View(companies);
        }
    }
}