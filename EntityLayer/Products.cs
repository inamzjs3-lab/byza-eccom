using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class Products : BaseEntity
    {
        [Required]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        [Required]
        public string Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }

    }
}
