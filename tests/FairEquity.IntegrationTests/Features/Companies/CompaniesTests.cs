namespace FairEquity.IntegrationTests.Features.Companies;

[Collection(AppHostCollection.Name)]
public sealed class CompaniesTests(AppHostFixture fixture)
{
    private sealed record CompanyDto(Guid Id, string Name, DateTimeOffset CreatedAt);

    [Fact]
    public async Task Created_company_can_be_fetched()
    {
        var ct = TestContext.Current.CancellationToken;
        using var client = fixture.CreateApiClient();

        var createResponse = await client.PostAsJsonAsync("/companies", new { Name = "Acme" }, ct);
        createResponse.StatusCode.ShouldBe(HttpStatusCode.Created);
        var created = await createResponse.Content.ReadFromJsonAsync<CompanyDto>(ct);

        var fetched = await client.GetFromJsonAsync<CompanyDto>(createResponse.Headers.Location, ct);

        fetched.ShouldNotBeNull();
        fetched.Id.ShouldBe(created!.Id);
        fetched.Name.ShouldBe("Acme");
    }

    [Fact]
    public async Task Create_with_empty_name_returns_validation_problem()
    {
        var ct = TestContext.Current.CancellationToken;
        using var client = fixture.CreateApiClient();

        var response = await client.PostAsJsonAsync("/companies", new { Name = "" }, ct);

        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }
}
