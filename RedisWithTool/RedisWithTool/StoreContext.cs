using Microsoft.EntityFrameworkCore;

namespace RedisWithTool
{
    public class StoreContext :DbContext
    {
        public DbSet<Product> Products { get; set; }

    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }

}
}
