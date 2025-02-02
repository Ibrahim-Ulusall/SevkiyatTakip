using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IIlceRepository : IRepository<int, Ilce>, IAsyncRepository<int, Ilce>
{
}
