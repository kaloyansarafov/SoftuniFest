using DWHApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DWHApi;

public class DWHDbContext : DbContext
{
    public DWHDbContext(DbContextOptions<DWHDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<Employee> Employees { get; set; }
}