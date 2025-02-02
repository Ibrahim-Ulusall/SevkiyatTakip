using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class UlkeRepository : EfRepositoryBase<int, Ulke, SevkiyatContext>, IUlkeRepository
{
    public UlkeRepository(SevkiyatContext context) : base(context)
    {
    }
}
