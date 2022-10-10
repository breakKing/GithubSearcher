using FastEndpoints;
using FluentValidation;
using GithubSearcherTest.Web.Contracts;

namespace GithubSearcherTest.Web.Validators;

public class HistoryRequestValidator : Validator<HistoryRequest>
{
    public HistoryRequestValidator()
    {
         RuleFor(r => r.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number should be positive");

        RuleFor(r => r.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size should be positive");
    }
}
