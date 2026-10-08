using FairEquity.Features.Common.Handlers;
using FairEquity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FairEquity.Features.Companies;

public static partial class GetCompany
{
    internal sealed class Handler(AppDbContext db) : IHandler
    {
        public Task<Response?> HandleAsync(Guid id, CancellationToken cancellationToken) =>
            db.Companies
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(Mapping.ToResponse)
                .SingleOrDefaultAsync(cancellationToken);
    }
}
