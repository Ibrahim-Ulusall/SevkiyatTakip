using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class FirmaYetkiliRepository : EfRepositoryBase<int, FirmaYetkili, SevkiyatContext>, IFirmaYetkiliRepository
{
    public FirmaYetkiliRepository(SevkiyatContext context) : base(context)
    {
    }
}
