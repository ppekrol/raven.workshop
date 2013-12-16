using System.Collections.Generic;
using Raven.Workshop.Web.Models;

namespace Raven.Workshop.Web.ViewModels
{
	public class CompaniesAndEmployeesViewModel
	{
		public List<Company> Companies { get; set; }

		public List<Employee> Employees { get; set; }
	}
}