using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IUlkeRepository : IRepository<int, Ulke>, IAsyncRepository<int, Ulke>
{
}
