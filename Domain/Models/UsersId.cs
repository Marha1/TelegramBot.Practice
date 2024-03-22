using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UsersId
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public long ChatID { get; set; }
        public string?Name { get; set; }
        
    }
}

