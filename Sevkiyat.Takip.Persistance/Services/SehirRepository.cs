﻿using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class SehirRepository : EfRepositoryBase<int, Sehir, SevkiyatContext>, ISehirRepository
{
    public SehirRepository(SevkiyatContext context) : base(context)
    {
    }
}
