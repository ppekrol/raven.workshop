// -----------------------------------------------------------------------
//  <copyright file="Company.cs" company="Hibernating Rhinos LTD">
//      Copyright (c) Hibernating Rhinos LTD. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Raven.Workshop.Web.Models
{
	public class Company
	{
		public string Id { get; set; }

		public List<Employee> Employees { get; set; }
	}
}