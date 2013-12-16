using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Raven.Workshop.Web.Helpers;
using Raven.Workshop.Web.Models;
using Raven.Workshop.Web.ViewModels;

namespace Raven.Workshop.Web.Controllers
{
	public class Ex3Controller : RavenController
	{
		 public ActionResult Index()
		 {
			 var model = new CompaniesAndEmployeesViewModel
				 {
					 Companies = RavenSession.Query<Company>().Customize(x => x.WaitForNonStaleResultsAsOfNow()).ToList(),
					 Employees = RavenSession.Query<Employee>().Customize(x => x.WaitForNonStaleResultsAsOfNow()).ToList()
				 };

			 return View(model);
		 }

		public ActionResult Add(string companyName)
		{
			RavenSession.Store(new Company
				{
					Name = companyName,
					EmployeeIds = new List<string>()
				});

			return RedirectToAction("Index");
		}

		public ActionResult Hire(string employeeId, string companyId)
		{
			var company = RavenSession.Load<Company>(companyId);
			company.EmployeeIds.Add(employeeId);

			return RedirectToAction("Index");
		}

		public ActionResult ShowCompany(string id)
		{
			var company = RavenSession.Include<Company>(x => x.EmployeeIds).Load(id);

			var employees = new List<string>();

			foreach (var employeeId in company.EmployeeIds)
			{
				var employee = RavenSession.Load<Employee>(employeeId);
				
				employees.Add(employee.FirstName + " " + employee.LastName);
			}

			var model = new CompanyViewModel()
			{
				CompanyName = company.Name,
				EmployeeFullNames = employees
			};

			return View(model);
		}
	}
}