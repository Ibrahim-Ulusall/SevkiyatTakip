using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IFirmaYetkiliRepository : IRepository<int, FirmaYetkili>, IAsyncRepository<int, FirmaYetkili>
{

}