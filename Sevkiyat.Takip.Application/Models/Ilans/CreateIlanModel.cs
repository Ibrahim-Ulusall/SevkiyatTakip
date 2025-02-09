namespace Sevkiyat.Takip.Application.Models.Ilans;
public class CreateIlanModel
{
    public int AlinacakIlceId { get; set; }
    public int FirmaId { get; set; }
    public int YukTipiId { get; set; }
    public int TasitTipiId { get; set; }
    public int KasaTipiId { get; set; }
    public DateTime YukAlimTarihi { get; set; }
    public DateTime? OnGorülenTeslimTarihi { get; set; }
    public string? Aciklama { get; set; }
    public int TeslimIlceId { get; set; }
}
