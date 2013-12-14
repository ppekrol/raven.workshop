// -----------------------------------------------------------------------
//  <copyright file="Ex2Controller.cs" company="Hibernating Rhinos LTD">
//      Copyright (c) Hibernating Rhinos LTD. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System.Web.Mvc;
using Raven.Workshop.Web.Models;

namespace Raven.Workshop.Web.Controllers
{
	public class Ex2Controller : RavenController
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(Employee model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			RavenSession.Store(model);

			return View(model);
		}
	}
}