using FluentValidation;
using Sevkiyat.Takip.Application.Models.TasitTips;

namespace Sevkiyat.Takip.Application.Validators.TasitTips;
public class CreateTasitTipiValidator : AbstractValidator<CreateTasitTipiModel>
{
    public CreateTasitTipiValidator()
    {
        RuleFor(i => i.Name).NotEmpty().NotNull();
    }
}
