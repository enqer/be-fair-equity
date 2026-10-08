using FairEquity.Domain.Companies;
using Microsoft.EntityFrameworkCore;

namespace FairEquity.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>Name of the database resource declared in the AppHost.</summary>
    public const string ConnectionName = "fairequity";

    public DbSet<Company> Companies => Set<Company>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}
