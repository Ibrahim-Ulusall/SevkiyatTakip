using Sevkiyat.Takip.Application.Models.Roles;
using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;

namespace Sevkiyat.Takip.Application.Services;

public interface IRoleRepository : IAsyncRepository<int, Role>, IRepository<int, Role>
{
    Task<IResult> CreateAsync(CreateRoleModel model);
    Task<IResult> RemoveAsync(int id);
}
