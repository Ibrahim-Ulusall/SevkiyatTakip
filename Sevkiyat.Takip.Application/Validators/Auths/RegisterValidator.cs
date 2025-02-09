using FluentValidation;
using Sevkiyat.Takip.Application.Models.Auths;

namespace Sevkiyat.Takip.Application.Validators.Auths;

public class RegisterValidator : AbstractValidator<RegisterModel>
{
    public RegisterValidator()
    {
        RuleFor(i => i.Email).EmailAddress().WithMessage("Email olması için @ gerekli.");
        RuleFor(i => i.FirstName).NotEmpty().NotNull();
        RuleFor(i => i.LastName).NotEmpty().NotNull();
        RuleFor(i => i.Password).NotEmpty().NotNull();
        RuleFor(i => i.Password).MinimumLength(8);
        RuleFor(i => i.Password).Must(AnyUpperChar).WithMessage("Parola en az bir büyük karakter içermelidir.");
        RuleFor(i => i.Password).Must(AnyLowerChar).WithMessage("Parola en az bir küçük karakter içermelidir.");
        RuleFor(i => i.Password).Must(AnyDigit).WithMessage("Parola en az bir rakam içermelidir.");
    }

    private bool AnyUpperChar(string arg)
    {
        return arg.Any(char.IsUpper);
    }

    private bool AnyLowerChar(string arg)
    {
        return arg.Any(char.IsLower);
    }

    private bool AnyDigit(string arg)
    {
        return arg.Any(char.IsDigit);
    }
}