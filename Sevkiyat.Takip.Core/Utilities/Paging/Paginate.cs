namespace Sevkiyat.Takip.Core.Utilities.Paging;
public class Paginate<T>
{
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public bool HasPrevious => Index > 0;
    public bool HasNext => Index + 1 < Pages;
    public IList<T>? Items { get; set; }
    public Paginate()
    {
        Items = Array.Empty<T>();
    }
}
