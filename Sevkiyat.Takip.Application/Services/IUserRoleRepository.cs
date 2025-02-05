using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IUserRoleRepository : IAsyncRepository<int,UserRole>, IRepository<int,UserRole>
{

}