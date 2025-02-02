using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Core.Utilities.Paging;

namespace Sevkiyat.Takip.Core.Extensions;
public static class IQueryablePaginateExtension
{

    public static async Task<Paginate<T>> ToPaginateAsync<T>(this IQueryable<T> queryable, int index,
        int size, CancellationToken cancellationToken)
    {
        int count = await queryable.CountAsync(cancellationToken).ConfigureAwait(false);

        List<T> items = await queryable.Skip(index * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);

        Paginate<T> list = new()
        {
            Count = count,
            Index = index,
            Items = items,
            Size = size,
            Pages = (int)Math.Ceiling((count / (double)size))
        };
        return list;
    }

    public static Paginate<T> ToPaginate<T>(this IQueryable<T> queryable, int index, int size)
    {
        int count = queryable.Count();

        List<T> items = queryable.Skip(index * size).Take(size).ToList();

        Paginate<T> list = new()
        {
            Index = index,
            Count = count,
            Items = items,
            Size = size,
            Pages = (int)Math.Ceiling(count / (double)size)
        };
        return list;
    }

}
