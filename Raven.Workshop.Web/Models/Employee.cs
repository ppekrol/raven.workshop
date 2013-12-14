// -----------------------------------------------------------------------
//  <copyright file="Employee.cs" company="Hibernating Rhinos LTD">
//      Copyright (c) Hibernating Rhinos LTD. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Raven.Workshop.Web.Models
{
	public class Employee
	{
		public string Id { get; set; }

		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		public uint Age { get; set; }
	}
}