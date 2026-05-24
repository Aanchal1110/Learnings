using System.ComponentModel.DataAnnotations;

namespace ModelBindingExample.Models
{
    public class Person
    {
        [Required(ErrorMessage ="Person name should be provided friend")]
        public string? PersonName { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person Name - {PersonName}, Email - {Email}, Phone - {Phone}, Password - {Password}, ConfirmPassword - {ConfirmPassword}, Price - {Price}";
        }

    }
}
