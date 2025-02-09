using FluentValidation;
using Sevkiyat.Takip.Application.Models.YulTips;

namespace Sevkiyat.Takip.Application.Validators.YukTips;
public class CreateYukTipValidator : AbstractValidator<CreateYukTipModel>
{
    public CreateYukTipValidator()
    {
        RuleFor(i => i.Name).NotEmpty().NotNull();
    }
}
