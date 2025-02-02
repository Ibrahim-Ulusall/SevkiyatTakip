namespace Sevkiyat.Takip.Core.Entities;
public interface IEntityTimeStamps
{
    DateTime CreatedDate { get; set; }
    DateTime? DeletedDate { get; set; }
    DateTime? UpdatedDate { get; set; }
}
