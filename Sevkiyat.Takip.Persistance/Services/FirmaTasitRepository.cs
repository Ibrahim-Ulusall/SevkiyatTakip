using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class FirmaTasitRepository : EfRepositoryBase<int, FirmaTasit, SevkiyatContext>, IFirmaTasitRepository
{
    public FirmaTasitRepository(SevkiyatContext context) : base(context)
    {
    }
}
