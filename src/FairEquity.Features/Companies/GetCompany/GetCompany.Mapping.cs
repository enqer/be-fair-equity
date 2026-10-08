using System.Linq.Expressions;
using FairEquity.Domain.Companies;

namespace FairEquity.Features.Companies;

public static partial class GetCompany
{
    internal static class Mapping
    {
        /// <summary>Expression so EF Core can translate the projection to SQL.</summary>
        public static readonly Expression<Func<Company, Response?>> ToResponse =
            company => new Response(company.Id, company.Name, company.CreatedAt);
    }
}
