using System.ComponentModel.DataAnnotations;

namespace AuctriaProject.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }
    }
}
