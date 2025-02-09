using FluentValidation;
using Sevkiyat.Takip.Core.Models.Auths;

namespace Sevkiyat.Takip.Application.Validators.Auths;
public class LoginValidator : AbstractValidator<LoginModel>
{
    public LoginValidator()
    {
        RuleFor(i=> i.Email).NotNull().NotEmpty().WithMessage("Email boş olamaz");
        RuleFor(i => i.Email).Must(ValidEmail).WithMessage("Email olması için @ gerekli.");
        RuleFor(i => i.Password).NotNull().NotEmpty().WithMessage("Password boş olamaz.");
    }

    private bool ValidEmail(string arg)
    {
        if (!arg.Contains("@"))
            return false;
        return true;
    }
}
