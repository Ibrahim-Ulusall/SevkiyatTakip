using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IFirmaRepository : IRepository<int,Firma> , IAsyncRepository<int, Firma>
{

}
