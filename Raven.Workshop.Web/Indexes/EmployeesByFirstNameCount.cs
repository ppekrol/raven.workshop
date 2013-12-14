using System.Linq;
using Raven.Client.Indexes;
using Raven.Workshop.Web.Models;

namespace Raven.Workshop.Web.Indexes
{
	public class EmployeesByFirstNameCount : AbstractIndexCreationTask<Employee, EmployeesByFirstNameCount.Result>
	{
		public class Result
		{
			public string EmployeeFirstName { get; set; }

			public int Count { get; set; }
		}

		public EmployeesByFirstNameCount()
		{
			Map = employees => from employee in employees
							   select new
							   {
								   Count = 1,
								   EmployeeFirstName = employee.FirstName
							   };

			Reduce = results => from result in results
								group result by result.EmployeeFirstName into g
								select new
								{
									EmployeeFirstName = g.Key,
									Count = g.Sum(x => x.Count)
								};
		}
	}
}