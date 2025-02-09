using FluentValidation;
using Sevkiyat.Takip.Application.Models.YulTips;

namespace Sevkiyat.Takip.Application.Validators.YukTips;

public class UpdateYukTipValidator : AbstractValidator<UpdateYukTipModel>
{
    public UpdateYukTipValidator()
    {
        RuleFor(i => i.Id).NotNull().NotEmpty();
        RuleFor(i => i.Name).NotNull().NotEmpty();
    }
}