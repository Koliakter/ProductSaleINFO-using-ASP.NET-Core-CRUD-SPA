using Microsoft.EntityFrameworkCore;

namespace ProductSaleINFO.Data
{
    public class SaleDBContext : DbContext
    {
        public SaleDBContext(DbContextOptions options) : base(options) { }
        public DbSet<SaleMaster> SaleMasters { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
    }
}
