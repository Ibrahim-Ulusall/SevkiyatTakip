using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class OperationClaimRepository : EfRepositoryBase<Guid, OperationClaim, SevkiyatContext>, IOperationClaimRepository
{
    public OperationClaimRepository(SevkiyatContext context) : base(context)
    {
    }
}
