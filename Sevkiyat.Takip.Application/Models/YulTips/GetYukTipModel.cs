namespace Sevkiyat.Takip.Application.Models.YulTips;

public class GetYukTipModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
