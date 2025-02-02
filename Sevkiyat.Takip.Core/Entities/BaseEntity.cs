
namespace Sevkiyat.Takip.Core.Entities;
public class BaseEntity<TId>: IEntityTimeStamps
{
    public TId? Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public BaseEntity() { }
    public BaseEntity(TId? id)
    {
        Id = id;
        CreatedDate = DateTime.Now;
    }
    public BaseEntity(TId? id, DateTime createdDate, DateTime? deletedDate, DateTime? updatedDate) : this(id)
    {
        CreatedDate = createdDate;
        DeletedDate = deletedDate;
        UpdatedDate = updatedDate;
    }
}
