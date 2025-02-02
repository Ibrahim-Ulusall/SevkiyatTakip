using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class FirmaRepository : EfRepositoryBase<int, Firma, SevkiyatContext>, IFirmaRepository
{
    public FirmaRepository(SevkiyatContext context) : base(context)
    {
    }
}
