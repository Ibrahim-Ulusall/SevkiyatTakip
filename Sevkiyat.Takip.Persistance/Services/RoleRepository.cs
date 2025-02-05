using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class RoleRepository : EfRepositoryBase<int, Role, SevkiyatContext>, IRoleRepository
{
    public RoleRepository(SevkiyatContext context) : base(context)
    {
    }
}
