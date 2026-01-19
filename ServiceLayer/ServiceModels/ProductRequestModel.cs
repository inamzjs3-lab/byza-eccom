using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ServiceModels
{
    public class ProductRequestModel
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [Required]
        public string ProductImage { get; set; }= string.Empty;
        [Required]
        public bool IsApproved { get; set; }

    }
}
