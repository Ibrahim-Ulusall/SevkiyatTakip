using FluentValidation;
using Sevkiyat.Takip.Application.Models.Firmas;

namespace Sevkiyat.Takip.Application.Validators.Firmas;
public class CreateFirmaValidator : AbstractValidator<CreateFirmaModel>
{
    public CreateFirmaValidator()
    {
        RuleFor(i => i.Name).NotEmpty().NotNull().MinimumLength(3);
    }
}
