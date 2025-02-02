using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class IlanRepository : EfRepositoryBase<int, Ilan, SevkiyatContext>, IIlanRepository
{
    public IlanRepository(SevkiyatContext context) : base(context)
    {
    }
}
