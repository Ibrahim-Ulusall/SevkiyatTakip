using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class UserTokenRepository : EfRepositoryBase<int, UserToken, SevkiyatContext>, IUserTokenRepository
{
    public UserTokenRepository(SevkiyatContext context) : base(context)
    {
    }
}
