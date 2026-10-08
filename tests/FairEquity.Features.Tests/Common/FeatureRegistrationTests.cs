using FairEquity.Features.Common.Endpoints;
using FairEquity.Features.Companies;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FairEquity.Features.Tests.Common;

public sealed class FeatureRegistrationTests
{
    private readonly IServiceCollection _services = new ServiceCollection().AddFeatures();

    [Fact]
    public void AddFeatures_registers_slice_endpoints()
    {
        var endpointTypes = _services
            .Where(d => d.ServiceType == typeof(IEndpoint))
            .Select(d => d.ImplementationType)
            .ToList();

        endpointTypes.ShouldContain(typeof(CreateCompany.Endpoint));
        endpointTypes.ShouldContain(typeof(GetCompany.Endpoint));
    }

    [Fact]
    public void AddFeatures_registers_slice_handlers_as_scoped()
    {
        _services.ShouldContain(d => d.ServiceType == typeof(CreateCompany.Handler) && d.Lifetime == ServiceLifetime.Scoped);
        _services.ShouldContain(d => d.ServiceType == typeof(GetCompany.Handler) && d.Lifetime == ServiceLifetime.Scoped);
    }

    [Fact]
    public void AddFeatures_registers_slice_validators()
    {
        _services.ShouldContain(d => d.ServiceType == typeof(IValidator<CreateCompany.Request>));
    }
}
