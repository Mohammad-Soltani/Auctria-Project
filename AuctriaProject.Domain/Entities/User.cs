using System.ComponentModel.DataAnnotations;

namespace AuctriaProject.Domain.Entities
{
    public class User : UserLogin
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [StringLength(30)]
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
