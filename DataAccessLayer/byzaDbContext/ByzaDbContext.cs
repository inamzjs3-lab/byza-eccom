using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.byzaDbContext
{
    public class ByzadbContext : DbContext
    {
        public ByzadbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }

}
