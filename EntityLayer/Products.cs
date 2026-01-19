using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class Products : BaseEntity
    {
 
        [Required]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        //[Required]
        public byte[] ProductImage { get; set; } 
        [Required]
        public bool IsApproved { get; set; }

    }
}
