namespace Sevkiyat.Takip.Application.Models.FirmaYetkilis;
public class FirmaYetkiliDetayModel
{
    public int Id { get; set; }
    public int FirmaId { get; set; }
    public Guid UserId { get; set; }
    public string Username { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
