using System.Linq;
using System.Web.Mvc;
using Raven.Workshop.Web.Models;

namespace Raven.Workshop.Web.Controllers
{
	public class Ex2Controller : RavenController
	{
		public ActionResult Index()
		{
			var employees = RavenSession.Query<Employee>().Customize(x => x.WaitForNonStaleResultsAsOfNow()).ToList();

			return View(employees);
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View("Edit");
		}

		[HttpPost]
		public ActionResult Edit(Employee model)
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
			var employee = RavenSession.Load<Employee>(id);

			return View(employee);
		}

		public ActionResult Delete(string id)
		{
			DocumentStore.DatabaseCommands.Delete(id, null);

			return RedirectToAction("Index");
		}
	}
}