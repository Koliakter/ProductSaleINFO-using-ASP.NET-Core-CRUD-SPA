namespace ProductSaleINFO.Models
{
    public partial class VmSale
    {
        public long SaleId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CustomerName { get; set; }
        public string? Gender { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }
        public string? Photo { get; set; }
        public List<VmSaleDetail> Details { get; set; } = new List<VmSaleDetail>();
        public string?[] ProductName { get; set; }
        public string?[] Color { get; set; }
        public decimal[] Price { get; set; }
        public decimal[] Qty { get; set; }
        public class VmSaleDetail
        {
            public long SaleDetailId { get; set; }
            public long SaleId { get; set; }
            public string? ProductName { get; set; }
            public string? Color { get; set; }
            public decimal Price { get; set; }
            public decimal Qty { get; set; }
        }
    }
  
}
