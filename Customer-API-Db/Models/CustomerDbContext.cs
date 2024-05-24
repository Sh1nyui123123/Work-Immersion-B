
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
    {
    }

    public DbSet<CustomerInfo> Customers { get; set; }
    public DbSet<Purchase> Purchases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerInfo>().ToTable("Customer");
        modelBuilder.Entity<Purchase>().ToTable("Purchase");
    }
}

public class CustomerInfo
{
    public int Id { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
}

public class Purchase
{
    public int Id_Product { get; set; }
    public string Name_Product { get; set; }
}



