namespace Sevkiyat.Takip.Application.Models.Ilans;

public class GetIlanModel
{
    public int Id { get; set; }
    public int AlinacakIlceId { get; set; }
    public int FirmaId { get; set; }
    public int YukTipiId { get; set; }
    public int TasitTipiId { get; set; }
    public int KasaTipiId { get; set; }
    public int TeslimIlceId { get; set; }
    public DateTime YukAlimTarihi { get; set; }
    public DateTime? OnGorülenTeslimTarihi { get; set; }
    public string? Aciklama { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string AlinacakSehir { get; set; } = null!;
    public string AlinacakIlce { get; set; } = null!;
    public string TeslimEdilecekSehir { get; set; } = null!;
    public string TeslimEdilecekIlce { get; set; } = null!;
    public string Firma { get; set; } = null!;
    public string TasitTipi { get; set; } = null!;
    public string KasaTipi { get; set; } = null!;
}