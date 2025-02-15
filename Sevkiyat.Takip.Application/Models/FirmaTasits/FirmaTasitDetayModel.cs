namespace Sevkiyat.Takip.Application.Models.FirmaTasits;
public class FirmaTasitDetayModel
{
    public int Id { get; set; }
    public int FirmaId { get; set; }
    public int TasitId { get; set; }
    public string Firma { get; set; } = null!;
    public string Tasit { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
