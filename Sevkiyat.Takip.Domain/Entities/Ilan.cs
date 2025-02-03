using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Ilan : BaseEntity<int>
{
    public int AlinacakIlceId { get; set; }
    public int TeslimEdilecekIlceId { get; set; }
    public int FirmaId { get; set; }
    public int YukTipiId { get; set; }
    public int TasitTipiId { get; set; }
    public int KasaTipiId { get; set; }
    public DateTime YukAlimTarihi { get; set; }
    public DateTime? OnGorulenTeslimTarihi { get; set; }
    public string? Aciklama { get; set; }
    public virtual Ilce AlinacakIlce { get; set; } = null!;
    public virtual Ilce TeslimEdilecekIlce { get; set; } = null!;
    public virtual Firma Firma { get; set; } = null!;
    public virtual YukTip YukTip { get; set; } = null!;
    public virtual TasitTip TasitTip { get; set; } = null!;
    public virtual KasaTip KasaTip { get; set; } = null!;
}