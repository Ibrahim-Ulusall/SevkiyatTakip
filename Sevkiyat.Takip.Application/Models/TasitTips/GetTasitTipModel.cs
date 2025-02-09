namespace Sevkiyat.Takip.Application.Models.TasitTips;

public class GetTasitTipModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
