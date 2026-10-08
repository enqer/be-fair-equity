using FairEquity.Domain.Companies;

namespace FairEquity.Domain.Tests.Companies;

public sealed class CompanyTests
{
    [Fact]
    public void Create_trims_name_and_assigns_id()
    {
        var now = new DateTimeOffset(2026, 1, 1, 12, 0, 0, TimeSpan.Zero);

        var company = Company.Create("  Acme  ", now);

        company.Name.ShouldBe("Acme");
        company.CreatedAt.ShouldBe(now);
        company.Id.ShouldNotBe(Guid.Empty);
    }
}
