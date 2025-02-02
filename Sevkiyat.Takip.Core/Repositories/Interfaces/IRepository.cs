using Microsoft.EntityFrameworkCore.Query;
using Sevkiyat.Takip.Core.Entities;
using Sevkiyat.Takip.Core.Utilities.Paging;
using System.Linq.Expressions;

namespace Sevkiyat.Takip.Core.Repositories.Interfaces;
public interface IRepository<TId, TEntity> where TEntity : BaseEntity<TId>
{
    TEntity Add(TEntity entity);
    TEntity Delete(TEntity entity, bool permanent = false);
    TEntity Update(TEntity entity);
    TEntity? Get(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true);
    bool Any(Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true);
    Paginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false, bool enableTracking = true,
        int index = 0, int size = 10);
    IList<TEntity> AddRange(IList<TEntity> entities);
    IList<TEntity> DeleteRange(IList<TEntity> entities, bool permanent = false);
    IList<TEntity> UpdateRange(IList<TEntity> entities);

}
