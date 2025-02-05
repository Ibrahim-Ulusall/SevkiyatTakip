using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class UserRoleRepository : EfRepositoryBase<int, UserRole, SevkiyatContext>, IUserRoleRepository
{
    public UserRoleRepository(SevkiyatContext context) : base(context)
    {
    }
}