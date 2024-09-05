using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RedisExp
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options) { }
        public DbSet<Product> Products
        {
            get;
            set;
        }
    }
}
