using FluentValidation;
using Sevkiyat.Takip.Application.Models.Firmas;

namespace Sevkiyat.Takip.Application.Validators.Firmas;

public class UpdateFirmaValidator : AbstractValidator<UpdateFirmaModel>
{
    public UpdateFirmaValidator()
    {
        RuleFor(i => i.Id).NotEmpty().Null();
        RuleFor(i => i.Name).NotEmpty().NotNull().MinimumLength(3);
    }
}
