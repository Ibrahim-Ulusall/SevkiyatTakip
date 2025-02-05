using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;

namespace Sevkiyat.Takip.Application.Services;

public interface ITokenTypeRepository : IAsyncRepository<int, TokenType>, IRepository<int, TokenType>
{

}
