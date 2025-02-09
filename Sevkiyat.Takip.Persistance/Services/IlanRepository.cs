using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Application.Models.Ilans;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Application.Validators.Ilans;
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

public class IlanRepository : EfRepositoryBase<int, Ilan, SevkiyatContext>, IIlanRepository
{
    private readonly IMapper _mapper;
    private readonly SevkiyatContext _context;
    public IlanRepository(SevkiyatContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
        _context = context;
    }

    [ValidationAspect(typeof(CreateIlanValidator))]
    [SecurityAspect("admin,ilan.add")]
    public async Task<IResult> CreateAsync(CreateIlanModel ilan)
    {

        var createIlan = _mapper.Map<Ilan>(ilan);
        await AddAsync(createIlan);

        return new SuccessResult(message: "Ilan oluşturuldu.");
    }

    [SecurityAspect("admin,ilan.delete")]
    public async Task<IResult> RemoveAsync(int id)
    {
        Ilan? ilan = await GetAsync(i => i.Id == id);

        if (ilan == null) throw new BusinessExceptionModel("İlan bulunamadı");

        await DeleteAsync(ilan);
        return new SuccessResult("Ilan silindi");
    }

    [SecurityAspect("admin,ilan.update")]
    [ValidationAspect(typeof(UpdateIlanValidator))]
    public async Task<IResult> UpdateAsync(UpdateIlanModel ilan)
    {
        Ilan? _ilan = _mapper.Map<Ilan>(ilan);
        await UpdateAsync(_ilan);
        return new SuccessResult("İlan başarıyla güncellendi.");
    }

    [SecurityAspect("admin,ilan.list")]
    public async Task<IDataResult<GetIlanModel>> GetAsync(int id)
    {
        GetIlanModel? ilan = await (from i in _context.Ilans
                                    where i.Id == id
                                    select new GetIlanModel
                                    {
                                        Id = i.Id,
                                        Aciklama = i.Aciklama,
                                        FirmaId = i.FirmaId,
                                        KasaTipiId = i.KasaTipiId,
                                        TasitTipiId = i.TasitTipiId,
                                        AlinacakIlceId = i.AlinacakIlceId,
                                        TeslimIlceId = i.TeslimIlceId,
                                        YukTipiId = i.YukTipiId,
                                        YukAlimTarihi = i.YukAlimTarihi,
                                        UpdatedDate = i.UpdatedDate,
                                        OnGorülenTeslimTarihi = i.OnGorülenTeslimTarihi,
                                        CreatedDate = i.CreatedDate,
                                        TasitTipi = i.TasitTipi.Name,
                                        KasaTipi = i.KasaTipi.Name,
                                        TeslimEdilecekSehir = i.TeslimIlce.Sehir.Name,
                                        AlinacakIlce = i.AlinacakIlce.Name,
                                        AlinacakSehir = i.AlinacakIlce.Sehir.Name,
                                        Firma = i.Firma.Adi,
                                        TeslimEdilecekIlce = i.TeslimIlce.Name
                                    }).FirstOrDefaultAsync() ?? throw new BusinessExceptionModel("Ilan Bulunamadı");

        return new SuccessDataResult<GetIlanModel>(data: ilan);
    }

    [SecurityAspect("admin,ilan.list")]
    public async Task<Paginate<GetIlanModel>> GetListForPaginateAsync(int? alinacakIlceId, int? teslimIlceId, int? firmaId,
        int? yukTipiId, int? tasitTipiId, int? kasaTipiId, DateTime? yukAlimTarihiBaslangic, DateTime? yukAlimTarihiBitis,
        int page = 1, int size = 10)
    {

        var result = await (from i in _context.Ilans
                            where (!alinacakIlceId.HasValue || alinacakIlceId.Value == i.AlinacakIlceId) &&
                                  (!teslimIlceId.HasValue || teslimIlceId.Value == i.TeslimIlceId) &&
                                  (!firmaId.HasValue || firmaId.Value == i.FirmaId) &&
                                  (!yukTipiId.HasValue || yukTipiId.Value == i.YukTipiId) &&
                                  (!tasitTipiId.HasValue || tasitTipiId.Value == i.TasitTipiId) &&
                                  (!kasaTipiId.HasValue || kasaTipiId.Value == i.KasaTipiId) &&
                                  (!yukAlimTarihiBaslangic.HasValue || yukAlimTarihiBaslangic.Value.Date >= i.YukAlimTarihi.Date
                                  && i.YukAlimTarihi.Date <= (yukAlimTarihiBitis.HasValue ? yukAlimTarihiBitis.Value.Date : DateTime.Now.Date ))
                            select new GetIlanModel
                            {
                                Id = i.Id,
                                Aciklama = i.Aciklama,
                                FirmaId = i.FirmaId,
                                KasaTipiId = i.KasaTipiId,
                                TasitTipiId = i.TasitTipiId,
                                AlinacakIlceId = i.AlinacakIlceId,
                                TeslimIlceId = i.TeslimIlceId,
                                YukTipiId = i.YukTipiId,
                                YukAlimTarihi = i.YukAlimTarihi,
                                UpdatedDate = i.UpdatedDate,
                                OnGorülenTeslimTarihi = i.OnGorülenTeslimTarihi,
                                CreatedDate = i.CreatedDate,
                                TasitTipi = i.TasitTipi.Name,
                                KasaTipi = i.KasaTipi.Name,
                                TeslimEdilecekSehir = i.TeslimIlce.Sehir.Name,
                                AlinacakIlce = i.AlinacakIlce.Name,
                                AlinacakSehir = i.AlinacakIlce.Sehir.Name,
                                Firma = i.Firma.Adi,
                                TeslimEdilecekIlce = i.TeslimIlce.Name
                            })
                            .OrderByDescending(i => i.Id)
                            .ToPaginateAsync(index: page - 1, size: size, cancellationToken: default);

        return result;
    }


}
