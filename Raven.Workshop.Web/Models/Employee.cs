namespace Raven.Workshop.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
	{
		public int Id { get; set; }

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