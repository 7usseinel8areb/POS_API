using Microsoft.EntityFrameworkCore;

namespace PointofSalesApi.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PurchaseInvoiceItem>()
           .HasOne(p => p.PurchaseInvoice)
           .WithMany(pi => pi.purchaseInvoiceItems)
           .HasForeignKey(p => p.PurchaseInvoiceId)
           .OnDelete(DeleteBehavior.Restrict); // Change to Restrict, SetNull, or NoAction based on your requirements

            // Similarly, configure other decimal properties for precision and scale
            builder.Entity<Employee>()
                .Property(e => e.Salary)
            .HasColumnType("decimal(18,2)");

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<PurchaseInvoice>()
                .Property(pi => pi.TotalAmount)
                .HasColumnType("decimal(18,2)");

            builder.Entity<PurchaseInvoiceItem>()
                .Property(pii => pii.UnitPrice)
                .HasColumnType("decimal(18,2)");

            builder.Entity<SalesInvoice>()
                .Property(si => si.TotalAmount)
                .HasColumnType("decimal(18,2)");

            builder.Entity<SalesInvoiceItem>()
                .Property(sii => sii.UnitPrice)
                .HasColumnType("decimal(18,2)");
        }

    }
}
