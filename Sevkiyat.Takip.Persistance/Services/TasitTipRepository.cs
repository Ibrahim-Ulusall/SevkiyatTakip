using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Application.Models.TasitTips;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Application.Validators.TasitTips;
using Sevkiyat.Takip.Core.Aspects.Security;
using Sevkiyat.Takip.Core.Aspects.Validation;
using Sevkiyat.Takip.Core.Models.Systems;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class TasitTipRepository : EfRepositoryBase<int, TasitTip, SevkiyatContext>, ITasitTipRepository
{
    private readonly SevkiyatContext _context;
    private readonly IMapper _mapper;
    public TasitTipRepository(SevkiyatContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    [SecurityAspect("admin", Priority = 1)]
    [ValidationAspect(typeof(CreateTasitTipiValidator), Priority = 2)]
    public async Task<IResult> CreateAsync(CreateTasitTipiModel tasitTipi)
    {
        bool tastiTipExists = await AnyAsync(i => i.Name.ToLower().Equals(tasitTipi.Name.ToLower()));
        if (tastiTipExists) throw new BusinessExceptionModel("Taşıt Tipi Sistemde Mevcut");

        TasitTip? tasitTip = _mapper.Map<TasitTip>(tasitTipi);
        await AddAsync(tasitTip);

        return new SuccessResult("Kayıt oluşturuldu.");
    }

    [SecurityAspect("admin")]
    public async Task<IResult> DeleteByIdAsync(int id)
    {
        TasitTip? tasitTip = await GetAsync(i => i.Id == id);
        if (tasitTip == null) throw new BusinessExceptionModel("Kayıt Bulunamadı");

        await DeleteAsync(tasitTip);
        return new SuccessResult("Kayıt Silindi");
    }

    public async Task<IDataResult<ICollection<GetTasitTipModel>>> GetAllAsync()
    {
        var result = await (from tt in _context.TasitTipleri
                            select new GetTasitTipModel
                            {
                                Id = tt.Id,
                                Name = tt.Name,
                                CreatedDate = tt.CreatedDate,
                                UpdatedDate = tt.UpdatedDate
                            }).ToListAsync();
        return new SuccessDataResult<ICollection<GetTasitTipModel>>(data: result);
    }

    public async Task<IDataResult<GetTasitTipModel>> GetByIdAsync(int id)
    {
        var result = await (from tt in _context.TasitTipleri
                            where tt.Id == id
                            select new GetTasitTipModel
                            {
                                Id = tt.Id,
                                Name = tt.Name,
                                CreatedDate = tt.CreatedDate,
                                UpdatedDate = tt.UpdatedDate
                            }).FirstOrDefaultAsync() ?? throw new BusinessExceptionModel("Kayıt Bulunamdı");
        return new SuccessDataResult<GetTasitTipModel>(data: result);
    }

    [SecurityAspect("admin", Priority = 1)]
    [ValidationAspect(typeof(UpdateTasitTipValidator), Priority = 2)]
    public async Task<IResult> UpdateWithModelAsync(UpdateTasitTipiModel model)
    {
        TasitTip tasitTip = _mapper.Map<TasitTip>(model);
        await UpdateAsync(tasitTip);

        return new SuccessResult("Kayıt Güncellendi");
    }
}
