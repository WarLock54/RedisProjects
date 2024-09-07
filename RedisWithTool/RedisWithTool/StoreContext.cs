using Microsoft.EntityFrameworkCore;
using RedisWithTool.Models;

namespace RedisWithTool
{
    public class StoreContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FindGeo> FindGeos { get; set; }
        public DbSet<GeoResult> GeoResults { get; set; }
        public DbSet<LocationDate> LocationDates { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }

}
}
