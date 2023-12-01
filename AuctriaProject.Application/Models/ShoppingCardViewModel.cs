using System.ComponentModel.DataAnnotations;

namespace AuctriaProject.Application.Models
{
    public class ShoppingCardViewModel : ItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
