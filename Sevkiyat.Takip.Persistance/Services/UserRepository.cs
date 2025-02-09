using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;
public class UserRepository : EfRepositoryBase<Guid, User, SevkiyatContext>, IUserRepository
{
    private readonly SevkiyatContext _context;
    public UserRepository(SevkiyatContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<OperationClaim>> GetUserClaims(Guid userId)
    {
        var claims = await (from u in _context.UserOperationClaims
                            where u.UserId == userId
                            select new OperationClaim
                            {
                                Id = u.OperationClaimId,
                                Name = u.OperationClaim.Name,
                                CreatedDate = u.OperationClaim.CreatedDate,
                                RoleId = u.OperationClaim.RoleId,
                                DeletedDate = u.OperationClaim.DeletedDate,
                                Role = u.OperationClaim.Role,
                                UpdatedDate = u.OperationClaim.UpdatedDate,
                            }).ToListAsync();

        return claims ?? new List<OperationClaim>();
    }
}
