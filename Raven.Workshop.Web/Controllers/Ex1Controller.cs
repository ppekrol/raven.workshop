namespace Raven.Workshop.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Raven.Abstractions.Data;

    public class Ex1Controller : RavenController
    {
        public ActionResult Index()
        {
            DatabaseStatistics stats = null;

            try
            {
                stats = DocumentStore != null
                              ? DocumentStore.DatabaseCommands.GetStatistics()
                              : null;
            }
            catch (Exception)
            {
            }

            return View(stats);
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