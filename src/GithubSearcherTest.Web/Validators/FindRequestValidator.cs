using FastEndpoints;
using FluentValidation;
using GithubSearcherTest.Web.Contracts;

namespace GithubSearcherTest.Web.Validators;

public class FindRequestValidator : Validator<FindRequest>
{
    public FindRequestValidator()
    {
        RuleFor(r => r.QueryText)
            .NotEmpty()
            .WithMessage("Can't handle an empty request");

        RuleFor(r => r.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number should be positive");

        RuleFor(r => r.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size should be positive");
    }
}
