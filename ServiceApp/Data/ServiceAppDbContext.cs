using Microsoft.EntityFrameworkCore;
using ServiceApp.Data.Entities;

namespace ServiceApp.Data;

public class ServiceAppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Device> Devices => Set<Device>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("ServiceAppDb");
    }
}