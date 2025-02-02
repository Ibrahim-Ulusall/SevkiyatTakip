using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class KasaTipRepository : EfRepositoryBase<int, KasaTip, SevkiyatContext>, IKasaTipRepository
{
    public KasaTipRepository(SevkiyatContext context) : base(context)
    {
    }
}
