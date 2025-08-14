using Microsoft.EntityFrameworkCore;
using QLDonHangAPI.Data.Entities;

namespace QLDonHangAPI.Data
{
    public class QLDonHangDbContext : DbContext
    {
        public QLDonHangDbContext(DbContextOptions<QLDonHangDbContext> context):base(context) { 
        }

        // register the classes 
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

    }
}
 
