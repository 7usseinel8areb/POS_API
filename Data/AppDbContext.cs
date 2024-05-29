namespace PointofSalesApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
