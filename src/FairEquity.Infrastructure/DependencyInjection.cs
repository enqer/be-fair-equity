using FairEquity.Infrastructure.Persistence;
using Microsoft.Extensions.Hosting;

namespace FairEquity.Infrastructure;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<AppDbContext>(AppDbContext.ConnectionName);

        return builder;
    }
}
