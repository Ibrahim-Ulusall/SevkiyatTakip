using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class TokenTypeRepository : EfRepositoryBase<int, TokenType, SevkiyatContext>, ITokenTypeRepository
{
    public TokenTypeRepository(SevkiyatContext context) : base(context)
    {
    }
}
