using FluentValidation;
using Sevkiyat.Takip.Application.Models.TasitTips;

namespace Sevkiyat.Takip.Application.Validators.TasitTips;

public class UpdateTasitTipValidator : AbstractValidator<UpdateTasitTipiModel>
{
    public UpdateTasitTipValidator()
    {
        RuleFor(i => i.Id).NotNull().NotEmpty();
        RuleFor(i => i.Name).NotEmpty().NotNull();
    }
}