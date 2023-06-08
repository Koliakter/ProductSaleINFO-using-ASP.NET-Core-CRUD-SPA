using System.ComponentModel.DataAnnotations;

namespace ProductSaleINFO.Data
{
    public class SaleDetail
    {
        [Key]
        public long SaleDetailId { get; set; }
        [Required]
        public long SaleId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Qty { get; set; }
    }
}
