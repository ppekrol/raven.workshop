namespace Raven.Workshop.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Raven.Workshop.Web.Models;

    public class Ex3Controller : RavenController
    {
        private void DeployData()
        {
            var employee1 = new Employee { Age = 30, FirstName = "Jan", LastName = "Nowak", Id = 5000 };
            var employee2 = new Employee { Age = 33, FirstName = "Krzysztof", LastName = "Nowak", Id = 5001 };
            var employee3 = new Employee { Age = 32, FirstName = "Edward", LastName = "Nowak", Id = 5002 };
            var employee4 = new Employee { Age = 40, FirstName = "Janusz", LastName = "Nowak", Id = 5003 };
            var employee5 = new Employee { Age = 39, FirstName = "Janina", LastName = "Nowak", Id = 5004 };
            var employee6 = new Employee { Age = 35, FirstName = "Julian", LastName = "Nowak", Id = 5005 };
            var employee7 = new Employee { Age = 37, FirstName = "Dominik", LastName = "Nowak", Id = 5006 };
            var employee8 = new Employee { Age = 39, FirstName = "Andrzej", LastName = "Nowak", Id = 5007 };
            var employee9 = new Employee { Age = 34, FirstName = "Zbigniew", LastName = "Nowak", Id = 5008 };
            var employee10 = new Employee { Age = 29, FirstName = "Agnieszka", LastName = "Nowak", Id = 5009 };

            var company1 = new Company
                               {
                                   Id = "company/1500",
                                   Name = "TGD-Company-A",
                                   EmployeeIds =
                                       new List<string> { "employees/5000", "employees/5001", "employees/5002" } // Jan, Krzysztof, Edward
                               };

            var company2 = new Company
                               {
                                   Id = "company/1501",
                                   Name = "TGD-Company-B",
                                   EmployeeIds =
                                       new List<string> { "employees/5003", "employees/5004", "employees/5005" } // Janusz, Janina, Julian
                               };

            var company3 = new Company
                               {
                                   Id = "company/1502",
                                   Name = "TGD-Company-99",
                                   EmployeeIds =
                                       new List<string> { "employees/5006", "employees/5007", "employees/5008", "employees/5009" } // Dominik, Andrzej, Zbigniew, Agnieszka
                               };

            RavenSession.Store(employee1);
            RavenSession.Store(employee2);
            RavenSession.Store(employee3);
            RavenSession.Store(employee4);
            RavenSession.Store(employee5);
            RavenSession.Store(employee6);
            RavenSession.Store(employee7);
            RavenSession.Store(employee8);
            RavenSession.Store(employee9);
            RavenSession.Store(employee10);

            RavenSession.Store(company1);
            RavenSession.Store(company2);
            RavenSession.Store(company3);
        }

        public ActionResult Index()
        {
            DeployData();

            var companies = RavenSession
                .Advanced
                .LuceneQuery<Company, IndexConfig.CompanyEmployees>()
                .WhereStartsWith("FirstName", "J")
                .ToList();

            return View(companies);
        }
    }
}