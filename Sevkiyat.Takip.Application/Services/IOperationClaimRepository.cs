using Sevkiyat.Takip.Application.Models.OperationClaims;
using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;
public interface IOperationClaimRepository : IAsyncRepository<Guid, OperationClaim>
{
    Task<IResult> CreateAsync(CreateOperationClaimModel model);
    Task<IResult> RemoveAsync(Guid id);
}
