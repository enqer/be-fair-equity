using FairEquity.Domain.Companies;

namespace FairEquity.Features.Companies;

public static partial class CreateCompany
{
    internal static class Mapping
    {
        public static Company ToDomain(Request request, DateTimeOffset createdAt) =>
            Company.Create(request.Name, createdAt);

        public static Response ToResponse(Company company) =>
            new(company.Id, company.Name, company.CreatedAt);
    }
}
