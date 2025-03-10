using System.ComponentModel.DataAnnotations;

namespace WardrobeInventory.hasona23.Models
{
    public class WearItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int Size { get; set; }
        [ColorValidation]
        public string Color { get; set; }

    }
}
