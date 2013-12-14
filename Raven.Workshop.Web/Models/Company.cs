// -----------------------------------------------------------------------
//  <copyright file="Company.cs" company="Hibernating Rhinos LTD">
//      Copyright (c) Hibernating Rhinos LTD. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

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