using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Application.Models.YulTips;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Application.Validators.YukTips;
using Sevkiyat.Takip.Core.Aspects.Security;
using Sevkiyat.Takip.Core.Aspects.Validation;
using Sevkiyat.Takip.Core.Models.Systems;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;
public class YukTipRepository : EfRepositoryBase<int, YukTip, SevkiyatContext>, IYukTipRepository
{
    private readonly SevkiyatContext _context;
    private readonly IMapper _mapper;
    public YukTipRepository(SevkiyatContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    [SecurityAspect("admin", Priority = 1)]
    [ValidationAspect(typeof(CreateYukTipValidator), Priority = 2)]
    public async Task<IResult> CreateAsync(CreateYukTipModel model)
    {
        YukTip yukTip = _mapper.Map<YukTip>(model);

        bool exists =await AnyAsync(i => i.Name.ToLower().Equals(model.Name.ToLower()));
        if (exists) throw new BusinessExceptionModel("Kayıt sistemde mevcut");

        await AddAsync(yukTip);
        return new SuccessResult("Kayıt oluşturuldu.");
    }

    [SecurityAspect("admin")]
    public async Task<IResult> RemoveAsync(int id)
    {
        YukTip? yukTip = await GetAsync(i => i.Id == id);
        if (yukTip == null) throw new BusinessExceptionModel("Kayıt Bulunamadı");

        await DeleteAsync(yukTip);
        return new SuccessResult("Kayıt Silindi");
    }

    [SecurityAspect("admin", Priority = 1)]
    [ValidationAspect(typeof(UpdateYukTipValidator), Priority = 2)]
    public async Task<IResult> UpdateWithModelAsync(UpdateYukTipModel model)
    {
        YukTip yukTip = _mapper.Map<YukTip>(model);
        await UpdateAsync(yukTip);
        return new SuccessResult("Kayıt Güncellendi.");
    }

    public async Task<IDataResult<ICollection<GetYukTipModel>>> GetAllAsync()
    {
        ICollection<GetYukTipModel> yukYips = await _context.YukTipleri.Select(i => new GetYukTipModel
        {
            Id = i.Id,
            Name = i.Name,
            CreatedDate = i.CreatedDate,
            UpdatedDate = i.UpdatedDate
        }).ToListAsync();

        return new SuccessDataResult<ICollection<GetYukTipModel>>(data: yukYips);
    }
    public async Task<IDataResult<GetYukTipModel>> GetByIdAsync(int id)
    {
        GetYukTipModel yukTip = await _context.YukTipleri.Select(i => new GetYukTipModel
        {
            Id = i.Id,
            Name = i.Name,
            CreatedDate = i.CreatedDate,
            UpdatedDate = i.UpdatedDate
        }).FirstOrDefaultAsync(i => i.Id == id) ?? throw new BusinessExceptionModel("Kayıt Bulunamadı");

        return new SuccessDataResult<GetYukTipModel>(data: yukTip);
    }

}
