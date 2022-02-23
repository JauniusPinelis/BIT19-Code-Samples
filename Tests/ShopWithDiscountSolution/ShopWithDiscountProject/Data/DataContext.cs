using Microsoft.EntityFrameworkCore;
using ShopWithDiscountProject.Models;

namespace ShopWithDiscountProject.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ShopItem> Shopitems { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
