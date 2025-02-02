using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class IlceRepository : EfRepositoryBase<int, Ilce, SevkiyatContext>, IIlceRepository
{
    public IlceRepository(SevkiyatContext context) : base(context)
    {
    }
}
