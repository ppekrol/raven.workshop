namespace Raven.Workshop.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Imię jest wymagane.")]
		[Display(Name = "Imię")]
		public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
		[Display(Name = "Nazwisko")]
		public string LastName { get; set; }

        [Required(ErrorMessage = "Wiek jest wymagany.")]
		[Display(Name = "Wiek")]
		public uint Age { get; set; }
	}
}