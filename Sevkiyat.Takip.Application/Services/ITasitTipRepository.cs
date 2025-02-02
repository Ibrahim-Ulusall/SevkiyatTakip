using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface ITasitTipRepository : IRepository<int, TasitTip>, IAsyncRepository<int, TasitTip>
{
}
