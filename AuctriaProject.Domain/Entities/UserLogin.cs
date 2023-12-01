using System.ComponentModel.DataAnnotations;

namespace AuctriaProject.Domain.Entities
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [StringLength(20, MinimumLength = 6)]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
