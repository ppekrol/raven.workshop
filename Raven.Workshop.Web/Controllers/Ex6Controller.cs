﻿using System.Linq;
using System.Web.Mvc;
using Raven.Client.Linq;
using Raven.Workshop.Web.Indexes;
using Raven.Workshop.Web.Models;
using Raven.Workshop.Web.Transformers;
using Raven.Workshop.Web.ViewModels;

namespace Raven.Workshop.Web.Controllers
{
	public class Ex6Controller : RavenController
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(string companyNamePrefix)
		{
			var result =
				RavenSession.Query<Company, CompanyByName>()
							.Where(c => c.Name.StartsWith(companyNamePrefix))
							.Customize(x => x.WaitForNonStaleResultsAsOfNow())
							.TransformWith<CompaniesWithEmployees, CompanyViewModel>();


			return View(result);
		}
	}
}