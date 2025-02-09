using Sevkiyat.Takip.Application.Models.Ilans;
using Sevkiyat.Takip.Application.Models.YulTips;
using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;
public interface IYukTipRepository : IRepository<int, YukTip>, IAsyncRepository<int, YukTip>
{
    Task<IResult> CreateAsync(CreateYukTipModel model);
    Task<IDataResult<ICollection<GetYukTipModel>>> GetAllAsync();
    Task<IDataResult<GetYukTipModel>> GetByIdAsync(int id);
    Task<IResult> RemoveAsync(int id);
    Task<IResult> UpdateWithModelAsync(UpdateYukTipModel model);
}
