using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface ISehirRepository : IRepository<int, Sehir>, IAsyncRepository<int, Sehir>
{
}
