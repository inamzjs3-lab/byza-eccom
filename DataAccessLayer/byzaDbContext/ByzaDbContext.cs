using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.byzaDbContext
{
    public class ByzadbContext : DbContext
    {
        public ByzadbContext(DbContextOptions options) : base(options)
        {
        }

    }

}
