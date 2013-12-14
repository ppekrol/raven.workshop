namespace Raven.Workshop.Web.Models
{
    using System.Collections.Generic;

    public class Company
	{
		public string Id { get; set; }

        public string Name { get; set; }

		public List<string> EmployeeIds { get; set; }
	}
}