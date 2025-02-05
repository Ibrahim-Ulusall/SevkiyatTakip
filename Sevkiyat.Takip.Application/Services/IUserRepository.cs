using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;
namespace Sevkiyat.Takip.Application.Services;
public interface IUserRepository : IAsyncRepository<Guid, User>, IRepository<Guid, User>
{

}