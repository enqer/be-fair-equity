using FairEquity.Features.Common.Endpoints;
using FairEquity.Features.Common.Validation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FairEquity.Features.Companies;

public static partial class CreateCompany
{
    public sealed record Request(string Name);

    public sealed record Response(Guid Id, string Name, DateTimeOffset CreatedAt);

    internal sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app) =>
            app.MapPost("/companies", InvokeAsync)
                .WithName(nameof(CreateCompany))
                .WithTags(nameof(Companies))
                .WithRequestValidation<Request>();

        private static async Task<CreatedAtRoute<Response>> InvokeAsync(
            Request request,
            Handler handler,
            CancellationToken cancellationToken)
        {
            var response = await handler.HandleAsync(request, cancellationToken);

            return TypedResults.CreatedAtRoute(response, nameof(GetCompany), new { id = response.Id });
        }
    }
}
