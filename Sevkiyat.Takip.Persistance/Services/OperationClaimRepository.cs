using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Application.Models.OperationClaims;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Application.Validators.OperationClaims;
using Sevkiyat.Takip.Core.Aspects.Security;
using Sevkiyat.Takip.Core.Aspects.Validation;
using Sevkiyat.Takip.Core.Models.Systems;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class OperationClaimRepository : EfRepositoryBase<Guid, OperationClaim, SevkiyatContext>, IOperationClaimRepository
{
    private readonly SevkiyatContext _context;
    public OperationClaimRepository(SevkiyatContext context) : base(context)
    {
        _context = context;
    }

    [SecurityAspect("admin")]
    [ValidationAspect(typeof(CreateOperationClaimValidator))]
    public async Task<IResult> CreateAsync(CreateOperationClaimModel model)
    {
        bool roleExists = await _context.Roles.AnyAsync(i => i.Id == model.RoleId);
        if (!roleExists)
            throw new BusinessExceptionModel(message: "Rol sistemde tanımlı değil.");

        bool isDuplicated = await AnyAsync(i => i.Name!.ToLower().Equals(model.Name.ToLower()) && i.RoleId == model.RoleId);
        if (isDuplicated)
            throw new BusinessExceptionModel(message: $"{model.Name} sistemde tanımlı.");

        await AddAsync(new OperationClaim()
        {
            Name = model.Name,
            RoleId = model.RoleId,
        });

        return new SuccessResult(message: "Kayıt Oluşturuldu.");
    }

    [SecurityAspect("admin")]
    public async Task<IResult> RemoveAsync(Guid id)
    {
        OperationClaim? claim = await GetAsync(i => i.Id == id);

        if (claim == null) throw new BusinessExceptionModel(message: "Sistemde kayıt bulunamadı.");

        await DeleteAsync(claim);
        return new SuccessResult(message: "Kayıt Silindi.");
    }
}
