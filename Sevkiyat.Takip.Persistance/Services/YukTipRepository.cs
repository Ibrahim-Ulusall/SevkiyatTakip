using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;
public class YukTipRepository : EfRepositoryBase<int, YukTip, SevkiyatContext>, IYukTipRepository
{
    public YukTipRepository(SevkiyatContext context) : base(context)
    {
    }
}
