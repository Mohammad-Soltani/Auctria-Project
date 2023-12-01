using System.ComponentModel.DataAnnotations;

namespace AuctriaProject.Domain.Entities
{
    public class ShoppingItem : Item
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
