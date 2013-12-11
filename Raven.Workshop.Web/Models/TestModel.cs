namespace Raven.Workshop.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TestModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}