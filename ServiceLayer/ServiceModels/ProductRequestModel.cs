using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceModels
{
    public class ProductRequestModel
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Price { get; set; }=string.Empty;
        [Required]
        public int StockQuantity { get; set; }
    }
}
