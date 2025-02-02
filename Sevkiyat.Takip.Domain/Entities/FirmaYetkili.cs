using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class FirmaYetkili : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public int FirmaId { get; set; }
    public virtual Firma Firma { get; set; } = null!;
    public virtual User User { get; set; } = null!;

    public FirmaYetkili() { }
    public FirmaYetkili(Guid userId, int firmaId)
    {
        UserId = userId;
        FirmaId = firmaId;
    }
}