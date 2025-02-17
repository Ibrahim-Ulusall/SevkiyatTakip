﻿using FluentValidation;
using Sevkiyat.Takip.Application.Models.Ilans;

namespace Sevkiyat.Takip.Application.Validators.Ilans;
public class CreateIlanValidator : AbstractValidator<CreateIlanModel>
{
    public CreateIlanValidator()
    {
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

