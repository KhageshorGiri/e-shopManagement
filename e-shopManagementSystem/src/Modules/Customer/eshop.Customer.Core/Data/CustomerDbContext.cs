
using eshop.Customer.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace eshop.Customer.Core.Data;

internal class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {
    }

    #region DBSET
    
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("customer");
    }
}
