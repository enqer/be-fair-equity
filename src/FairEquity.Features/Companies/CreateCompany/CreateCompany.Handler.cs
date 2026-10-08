using FairEquity.Features.Common.Handlers;
using FairEquity.Infrastructure.Persistence;

namespace FairEquity.Features.Companies;

public static partial class CreateCompany
{
    internal sealed class Handler(AppDbContext db, TimeProvider timeProvider) : IHandler
    {
        public async Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)
        {
            var company = Mapping.ToDomain(request, timeProvider.GetUtcNow());

            db.Companies.Add(company);
            await db.SaveChangesAsync(cancellationToken);

            return Mapping.ToResponse(company);
        }
    }
}
