using FluentValidation;
using Sevkiyat.Takip.Application.Models.Ilans;

namespace Sevkiyat.Takip.Application.Validators.Ilans;

public class UpdateIlanValidator : AbstractValidator<UpdateIlanModel>
{
    public UpdateIlanValidator()
    {
        RuleFor(i => i.Id).NotEmpty().NotNull();
        RuleFor(i => i.AlinacakIlceId).NotNull().NotEmpty();
        RuleFor(i => i.YukTipiId).NotNull().NotEmpty();
        RuleFor(i => i.KasaTipiId).NotNull().NotEmpty();
        RuleFor(i => i.FirmaId).NotNull().NotEmpty();
        RuleFor(i => i.TeslimIlceId).NotNull().NotEmpty();
        RuleFor(i => i.TasitTipiId).NotNull().NotEmpty();
        RuleFor(i => i.YukAlimTarihi).Must(ValidYukAlimTarihi).NotNull().NotEmpty();
    }

    private bool ValidYukAlimTarihi(DateTime time)
    {
        return time.Date >= DateTime.Now.Date;
    }
}

