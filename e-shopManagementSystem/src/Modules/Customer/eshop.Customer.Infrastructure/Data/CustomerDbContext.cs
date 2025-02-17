
using Microsoft.EntityFrameworkCore;

namespace eshop.Customer.Infrastructure.Data;

internal class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("customer");
    }
}
