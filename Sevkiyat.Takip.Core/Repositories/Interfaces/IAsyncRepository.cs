using Microsoft.EntityFrameworkCore.Query;
using Sevkiyat.Takip.Core.Entities;
using Sevkiyat.Takip.Core.Utilities.Paging;
using System.Linq.Expressions;

namespace Sevkiyat.Takip.Core.Repositories.Interfaces;

public interface IAsyncRepository<TId, TEntity> where TEntity : BaseEntity<TId>
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true, CancellationToken cancellationToken = default);
    Task<Paginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false, bool enableTracking = true,
        int index = 0, int size = 10, CancellationToken cancellationToken = default);
    Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entities);
    Task<IList<TEntity>> DeleteRangeAsync(IList<TEntity> entities, bool permanent = false);
    Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities);

}
