using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IFirmaTasitRepository : IRepository<int,FirmaTasit> , IAsyncRepository<int, FirmaTasit>
{

}
