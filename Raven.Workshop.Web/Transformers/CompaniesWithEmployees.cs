using System.Linq;
using Raven.Client.Indexes;
using Raven.Workshop.Web.Models;

namespace Raven.Workshop.Web.Transformers
{
	public class CompaniesWithEmployees : AbstractTransformerCreationTask<Company>
	{
		public CompaniesWithEmployees()
		{
			TransformResults = companies => from company in companies
											select new
											{
												CompanyName = company.Name,
												EmployeeFullNames = from employeeId in company.EmployeeIds
																	let employee = LoadDocument<Employee>(employeeId)
																	select employee.FirstName + " " + employee.LastName
											};
		}
	}
}