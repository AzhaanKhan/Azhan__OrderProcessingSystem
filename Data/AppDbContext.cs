using Microsoft.EntityFrameworkCore;
using OrderProcessingSystem.Models; // Add this line


public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne()
            .HasForeignKey("CustomerId"); // Correctly specify the foreign key as a string

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Products);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=orders.db");
    }
}
