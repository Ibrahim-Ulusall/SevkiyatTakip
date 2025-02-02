using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IIlanRepository : IRepository<int,Ilan> , IAsyncRepository<int, Ilan>
{

}

