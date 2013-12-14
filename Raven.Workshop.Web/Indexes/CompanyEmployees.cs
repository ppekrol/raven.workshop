using System.Linq;
using Raven.Client.Indexes;
using Raven.Workshop.Web.Models;

namespace Raven.Workshop.Web.Indexes
{
	public class CompanyEmployees : AbstractIndexCreationTask<Company>
	{
		public CompanyEmployees()
		{
			Map = companies => from company in companies
							   from employee in LoadDocument<Employee>(company.EmployeeIds)
							   select
								   new
								   {
									   FirstName = employee.FirstName
								   };
		}
	}
}