using FairEquity.Domain.Companies;
using FairEquity.Features.Companies;

namespace FairEquity.Features.Tests.Companies;

public sealed class CreateCompanyValidatorTests
{
    private readonly CreateCompany.RequestValidator _validator = new();

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Rejects_empty_name(string name) =>
        _validator.Validate(new CreateCompany.Request(name)).IsValid.ShouldBeFalse();

    [Fact]
    public void Rejects_name_longer_than_max_length() =>
        _validator.Validate(new CreateCompany.Request(new string('a', Company.NameMaxLength + 1))).IsValid.ShouldBeFalse();

    [Fact]
    public void Accepts_valid_name() =>
        _validator.Validate(new CreateCompany.Request("Acme")).IsValid.ShouldBeTrue();
}
