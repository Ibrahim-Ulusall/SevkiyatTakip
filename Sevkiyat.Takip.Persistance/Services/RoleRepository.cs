using Sevkiyat.Takip.Application.Models.Roles;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Application.Validators.Roles;
using Sevkiyat.Takip.Core.Aspects.Security;
using Sevkiyat.Takip.Core.Aspects.Validation;
using Sevkiyat.Takip.Core.Models.Systems;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities.MuhasebeEntities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class RoleRepository : EfRepositoryBase<int, Role, SevkiyatContext>, IRoleRepository
{
    private readonly SevkiyatContext _context;
    public RoleRepository(SevkiyatContext context) : base(context)
    {
        _context = context;
    }

    [SecurityAspect("admin")]
    [ValidationAspect(typeof(CreateRoleValidator))]
    public async Task<IResult> CreateAsync(CreateRoleModel model)
    {
        bool exists = await AnyAsync(i => i.Name.ToLower().Equals(model.Name.ToLower()));
        if (exists)
            throw new BusinessExceptionModel(message: $"{model.Name} sistemde tanımlı");

        await AddAsync(new()
        {
            Name = model.Name
        });

        return new SuccessResult(message: "Kayıt oluşturuldu.");
    }

    [SecurityAspect("admin")]
    public async Task<IResult> RemoveAsync(int id)
    {
        Role? role = await GetAsync(i => i.Id == id);
        if (role == null)
            throw new BusinessExceptionModel(message: "Kayıt Bulunamadı");
        await DeleteAsync(role);

        return new SuccessResult(message: "Kayıt Silindi.");
    }
}
