using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IUserOperationClaimRepository : IAsyncRepository<Guid, UserOperationClaim>, IRepository<Guid, UserOperationClaim>
{

}
