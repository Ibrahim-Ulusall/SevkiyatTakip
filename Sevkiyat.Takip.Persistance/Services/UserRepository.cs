using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;
public class UserRepository : EfRepositoryBase<Guid, User, SevkiyatContext>, IUserRepository
{
    public UserRepository(SevkiyatContext context) : base(context)
    {
    }
}
