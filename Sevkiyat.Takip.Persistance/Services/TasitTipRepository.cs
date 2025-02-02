using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class TasitTipRepository : EfRepositoryBase<int, TasitTip, SevkiyatContext>, ITasitTipRepository
{
    public TasitTipRepository(SevkiyatContext context) : base(context)
    {
    }
}
