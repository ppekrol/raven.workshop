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
    }
}