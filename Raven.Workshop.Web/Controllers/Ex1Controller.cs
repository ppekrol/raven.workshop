namespace Raven.Workshop.Web.Controllers
{
    using System.Web.Mvc;

	public class Ex1Controller : RavenController
    {
        public ActionResult Index()
        {
	        var dbStats = DocumentStore != null
							  ? DocumentStore.DatabaseCommands.GetStatistics()
		                      : null;

            return View(dbStats);
        }

		//[HttpPost]
		//public ActionResult Index(TestModel model)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return View(model);
		//	}

		//	return View(model);
		//}
    }
}