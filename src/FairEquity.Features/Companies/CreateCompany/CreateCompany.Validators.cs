using FairEquity.Domain.Companies;
using FluentValidation;

namespace FairEquity.Features.Companies;

public static partial class CreateCompany
{
    internal sealed class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(Company.NameMaxLength);
        }
    }
}
