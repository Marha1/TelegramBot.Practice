using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public int Age { get; set; }
        [Required]

        public string? Post { get; set; }
        public DateTime DateOfBirh { get; set; }

    }
}
