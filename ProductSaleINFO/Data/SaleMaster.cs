using System.ComponentModel.DataAnnotations;

namespace ProductSaleINFO.Data
{
    public class SaleMaster
    {
        [Key]
        public long SaleId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Photo { get; set; }
    }
}
