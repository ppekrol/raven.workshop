namespace Raven.Workshop.Web
{
    using System.Linq;

    using Raven.Client;
    using Raven.Client.Indexes;
    using Raven.Workshop.Web.Models;

    public class IndexConfig
    {
        public static void DeployIndexes(IDocumentStore store)
        {
            new CompanyEmployees().Execute(store);
            new EmployeesByFirstNameCount().Execute(store);
        }

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
}