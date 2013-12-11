namespace Raven.Workshop.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : RavenController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
