using Sevkiyat.Takip.Application.Models.TasitTips;
using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface ITasitTipRepository : IRepository<int, TasitTip>, IAsyncRepository<int, TasitTip>
{
    Task<IResult> CreateAsync(CreateTasitTipiModel tasitTipi);
    Task<IResult> DeleteByIdAsync(int id);
    Task<IDataResult<ICollection<GetTasitTipModel>>> GetAllAsync();
    Task<IDataResult<GetTasitTipModel>> GetByIdAsync(int id);
    Task<IResult> UpdateWithModelAsync(UpdateTasitTipiModel model);
}
