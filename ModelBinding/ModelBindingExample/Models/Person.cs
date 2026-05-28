using ModelBindingExample.CustomValidator;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingExample.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Person name should be provided friend")]
        [DisplayName("Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Person name should be between {2} and {1} characters")]

        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabets, space and dot(.)")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Please enter a proper phone number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Please enter the password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please enter the confirm password")]
        [Compare("Password", ErrorMessage = "{0} and Password don't match")]
        [DisplayName("Re- enter password")]
        public string? ConfirmPassword { get; set; }

        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person Name - {PersonName}, Email - {Email}, Phone - {Phone}, Password - {Password}, ConfirmPassword - {ConfirmPassword}, Price - {Price}";
        }

        [MinimumYearValidator]
        public DateTime? DOB { get; set; }

    }
}
