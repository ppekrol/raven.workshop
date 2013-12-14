namespace Raven.Workshop.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Imię")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Nazwisko")]
		public string LastName { get; set; }

		[Required]
		[Display(Name = "Wiek")]
		public uint Age { get; set; }
	}
}