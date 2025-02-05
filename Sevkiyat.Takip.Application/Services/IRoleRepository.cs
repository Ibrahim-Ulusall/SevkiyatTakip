using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;

namespace Sevkiyat.Takip.Application.Services;

public interface IRoleRepository : IAsyncRepository<int, Role>, IRepository<int, Role>
{

}
