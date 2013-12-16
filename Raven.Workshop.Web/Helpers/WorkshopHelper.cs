namespace Raven.Workshop.Web.Helpers
{
    using System.Collections.Generic;

    using Raven.Client;
    using Raven.Workshop.Web.Models;

    public static class WorkshopHelper
    {
        public static bool IsConnected { get; set; }

        public static void DeployData(IDocumentSession session)
        {
            var employee1 = new Employee { Age = 30, FirstName = "Jan", LastName = "Nowak", Id = "employees/" + 5000 };
			var employee2 = new Employee { Age = 33, FirstName = "Krzysztof", LastName = "Nowak", Id = "employees/" + 5001 };
			var employee3 = new Employee { Age = 32, FirstName = "Edward", LastName = "Nowak", Id = "employees/" + 5002 };
			var employee4 = new Employee { Age = 40, FirstName = "Janusz", LastName = "Nowak", Id = "employees/" + 5003 };
			var employee5 = new Employee { Age = 39, FirstName = "Janina", LastName = "Nowak", Id = "employees/" + 5004 };
			var employee6 = new Employee { Age = 35, FirstName = "Julian", LastName = "Nowak", Id = "employees/" + 5005 };
			var employee7 = new Employee { Age = 37, FirstName = "Dominik", LastName = "Nowak", Id = "employees/" + 5006 };
			var employee8 = new Employee { Age = 39, FirstName = "Andrzej", LastName = "Nowak", Id = "employees/" + 5007 };
			var employee9 = new Employee { Age = 34, FirstName = "Zbigniew", LastName = "Nowak", Id = "employees/" + 5008 };
			var employee10 = new Employee { Age = 29, FirstName = "Agnieszka", LastName = "Nowak", Id = "employees/" + 5009 };
			var employee11 = new Employee { Age = 29, FirstName = "Dominik", LastName = "Nowak", Id = "employees/" + 5010 };
			var employee12 = new Employee { Age = 29, FirstName = "Andrzej", LastName = "Nowak", Id = "employees/" + 5011 };
			var employee13 = new Employee { Age = 29, FirstName = "Dominik", LastName = "Nowak", Id = "employees/" + 5013 };

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

            session.Store(employee1);
            session.Store(employee2);
            session.Store(employee3);
            session.Store(employee4);
            session.Store(employee5);
            session.Store(employee6);
            session.Store(employee7);
            session.Store(employee8);
            session.Store(employee9);
            session.Store(employee10);
            session.Store(employee11);
            session.Store(employee12);
            session.Store(employee13);

            session.Store(company1);
            session.Store(company2);
            session.Store(company3);
        }
    }
}