using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FairEquity.Infrastructure.Persistence;

/// <summary>
/// Used only by <c>dotnet ef</c> at design time, so migrations can be created without running the AppHost.
/// </summary>
internal sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql("Host=localhost;Database=fairequity")
            .Options;

        return new AppDbContext(options);
    }
}
