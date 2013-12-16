using System.Collections.Generic;

namespace Raven.Workshop.Web.ViewModels
{
	public class CompanyViewModel
	{
		public string CompanyName { get; set; }

		public IEnumerable<string> EmployeeFullNames { get; set; }
	}
}