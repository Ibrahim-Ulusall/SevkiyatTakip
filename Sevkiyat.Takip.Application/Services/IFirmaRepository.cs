using Sevkiyat.Takip.Application.Models.Firmas;
using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Core.Utilities.Paging;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IFirmaRepository : IRepository<int, Firma>, IAsyncRepository<int, Firma>
{
    Task<IResult> CreateAsync(CreateFirmaModel model);
    Task<IResult> EditAsync(UpdateFirmaModel model);
    Task<Paginate<FirmaDetayModel>> GetAllAsync(string? adi, int index, int size);
    Task<IDataResult<FirmaDetayModel>> GetById(int id);
    Task<IResult> RemoveAsync(int id);
}

