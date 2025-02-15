using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Application.Models.Firmas;
using Sevkiyat.Takip.Application.Models.FirmaTasits;
using Sevkiyat.Takip.Application.Models.FirmaYetkilis;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Application.Validators.Firmas;
using Sevkiyat.Takip.Core.Aspects.Security;
using Sevkiyat.Takip.Core.Aspects.Validation;
using Sevkiyat.Takip.Core.Extensions;
using Sevkiyat.Takip.Core.Models.Systems;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Core.Utilities.Paging;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class FirmaRepository : EfRepositoryBase<int, Firma, SevkiyatContext>, IFirmaRepository
{
    private readonly SevkiyatContext _context;
    public FirmaRepository(SevkiyatContext context) : base(context)
    {
        _context = context;
    }

    [SecurityAspect("admin")]
    [ValidationAspect(typeof(CreateFirmaValidator))]
    public async Task<IResult> CreateAsync(CreateFirmaModel model)
    {
        bool duplicated = await AnyAsync(i => i.Adi.ToLower().Equals(model.Name.ToLower()));
        if (duplicated)
            throw new BusinessExceptionModel(message: $"{model.Name} Sistemde Tanımlı");

        await AddAsync(new Firma()
        {
            Adi = model.Name,
        });
        return new SuccessResult(message: "Kayıt oluşturuldu.");
    }

    [SecurityAspect("admin")]
    [ValidationAspect(typeof(UpdateFirmaValidator))]
    public async Task<IResult> EditAsync(UpdateFirmaModel model)
    {
        Firma? firma = await GetAsync(i => i.Id == model.Id);

        if (firma == null) throw new BusinessExceptionModel(message: "Firma Bulunamadı");
        firma.Adi = model.Name;
        await UpdateAsync(firma);

        return new SuccessResult(message: "Firma Güncellendi.");
    }

    public async Task<Paginate<FirmaDetayModel>> GetAllAsync(string? adi, int index, int size)
    {
        Paginate<FirmaDetayModel>? firmas = await (from f in _context.Firmas
                                                   where (string.IsNullOrEmpty(adi) || f.Adi.ToLower().Equals(adi.ToLower()))
                                                   select new FirmaDetayModel
                                                   {
                                                       Id = f.Id,
                                                       Adi = f.Adi,
                                                       FirmaYetkilis = f.FirmaYetkililers.Select(i => new FirmaYetkiliDetayModel
                                                       {
                                                           Id = i.Id,
                                                           FirmaId = i.FirmaId,
                                                           UserId = i.UserId,
                                                           Username = i.User.FullName,
                                                           UpdatedDate = i.UpdatedDate,
                                                           CreatedDate = i.CreatedDate
                                                       }).ToList(),
                                                       FirmaTasits = f.FirmaTasitlars.Select(i => new FirmaTasitDetayModel
                                                       {
                                                           Id = i.Id,
                                                           FirmaId = i.FirmaId,
                                                           TasitId = i.TasitTipId,
                                                           UpdatedDate = i.UpdatedDate,
                                                           CreatedDate = i.CreatedDate,
                                                           Firma = i.Firma.Adi,
                                                           Tasit = i.TasitTip.Name
                                                       }).ToList()
                                                   }).ToPaginateAsync(index: index - 1, size: size);
        return firmas;
    }

    public async Task<IDataResult<FirmaDetayModel>> GetById(int id)
    {
        FirmaDetayModel? firma = await (from f in _context.Firmas
                                        where f.Id == id
                                        select new FirmaDetayModel
                                        {
                                            Id = f.Id,
                                            Adi = f.Adi,
                                            FirmaYetkilis = f.FirmaYetkililers.Select(i => new FirmaYetkiliDetayModel
                                            {
                                                Id = i.Id,
                                                FirmaId = i.FirmaId,
                                                UserId = i.UserId,
                                                Username = i.User.FullName,
                                                UpdatedDate = i.UpdatedDate,
                                                CreatedDate = i.CreatedDate
                                            }).ToList(),
                                            FirmaTasits = f.FirmaTasitlars.Select(i => new FirmaTasitDetayModel
                                            {
                                                Id = i.Id,
                                                FirmaId = i.FirmaId,
                                                TasitId = i.TasitTipId,
                                                UpdatedDate = i.UpdatedDate,
                                                CreatedDate = i.CreatedDate,
                                                Firma = i.Firma.Adi,
                                                Tasit = i.TasitTip.Name
                                            }).ToList()
                                        }).FirstOrDefaultAsync();

        if (firma == null) throw new BusinessExceptionModel(message: "Firma bulunamadı");
        return new SuccessDataResult<FirmaDetayModel>(data: firma);
    }

    [SecurityAspect("admin")]
    public async Task<IResult> RemoveAsync(int id)
    {
        Firma? firma = await GetAsync(i => i.Id == id);
        if (firma == null) throw new BusinessExceptionModel(message: "Firma Sistemde Tanımı Değil");

        await DeleteAsync(firma);
        return new SuccessResult(message: "Kayıt Silindi.");
    }
}
