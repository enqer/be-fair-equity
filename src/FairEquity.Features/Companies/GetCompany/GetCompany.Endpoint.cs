using FairEquity.Features.Common.Endpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FairEquity.Features.Companies;

public static partial class GetCompany
{
    public sealed record Response(Guid Id, string Name, DateTimeOffset CreatedAt);

    internal sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app) =>
            app.MapGet("/companies/{id:guid}", InvokeAsync)
                .WithName(nameof(GetCompany))
                .WithTags(nameof(Companies));

        private static async Task<Results<Ok<Response>, NotFound>> InvokeAsync(
            Guid id,
            Handler handler,
            CancellationToken cancellationToken)
        {
            var response = await handler.HandleAsync(id, cancellationToken);

            return response is null ? TypedResults.NotFound() : TypedResults.Ok(response);
        }
    }
}
