using System.Linq;
using System.Web.Mvc;
using Raven.Workshop.Web.Models;

namespace Raven.Workshop.Web.Controllers
{
	public class Ex2Controller : RavenController
	{
		public ActionResult Index()
		{
			return View(RavenSession.Query<Employee>().ToList());
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(Employee model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			RavenSession.Store(model);

			return RedirectToAction("Index");
		}

		public ActionResult Edit(string id)
		{
			return View("Add", RavenSession.Load<Employee>(id));
		}

		public ActionResult Delete(string id)
		{
			RavenSession.Advanced.DocumentStore.DatabaseCommands.Delete(id, null);

			return RedirectToAction("Index");
		}
	}
}