namespace Raven.Workshop.Web.Controllers
{
    using System.Web.Mvc;

    using Raven.Workshop.Web.Models;

    public class Ex1Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }
    }
}