using FluentValidation;
using GithubSearcherTest.Web.Contracts;

namespace GithubSearcherTest.Web.Validators;

public class SignUpRequestValidator : Validator<SignUpRequest>
{
    public SignUpRequestValidator()
    {
        RuleFor(r => r.Username)
            .NotEmpty()
            .WithMessage("Username can't be empty");

        RuleFor(r => r.Password)
            .NotEmpty()
            .WithMessage("Password can't be empty");

        RuleFor(r => r.PasswordRepeat)
            .Equal(r => r.Password)
            .WithMessage("Password and PasswordRepeat should be equal");
    }
}
