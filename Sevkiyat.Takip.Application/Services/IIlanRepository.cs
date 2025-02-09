using Sevkiyat.Takip.Application.Models.Ilans;
using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Core.Utilities.Paging;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IIlanRepository : IRepository<int, Ilan>, IAsyncRepository<int, Ilan>
{
    Task<IResult> CreateAsync(CreateIlanModel ilan);
    Task<IResult> RemoveAsync(int id);
    Task<IResult> UpdateAsync(UpdateIlanModel ilan);
    Task<IDataResult<GetIlanModel>> GetAsync(int id);
    Task<Paginate<GetIlanModel>> GetListForPaginateAsync(int? alinacakIlceId, int? teslimIlceId, int? firmaId,
        int? yukTipiId, int? tasitTipiId, int? kasaTipiId, DateTime? yukAlimTarihiBaslangic, DateTime? yukAlimTarihiBitis,
        int page = 1, int size = 10);
}

