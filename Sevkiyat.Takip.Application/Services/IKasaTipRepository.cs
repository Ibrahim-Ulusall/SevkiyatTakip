using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IKasaTipRepository : IRepository<int, KasaTip>, IAsyncRepository<int, KasaTip>
{
}
