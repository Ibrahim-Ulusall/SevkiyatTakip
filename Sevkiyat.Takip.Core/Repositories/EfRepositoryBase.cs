﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Sevkiyat.Takip.Core.Entities;
using Sevkiyat.Takip.Core.Extensions;
using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Core.Utilities.Paging;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace Sevkiyat.Takip.Core.Repositories;
public class EfRepositoryBase<TId, TEntity, TContext> : IAsyncRepository<TId, TEntity>, IRepository<TId, TEntity>
    where TEntity : BaseEntity<TId> where TContext : DbContext

{
    private readonly TContext _context;

    public EfRepositoryBase(TContext context)
    {
        _context = context;
    }

    public TEntity Add(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        _context.Add(entity);
        _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public IList<TEntity> AddRange(IList<TEntity> entities)
    {
        foreach (TEntity entity in entities)
            entity.CreatedDate = DateTime.UtcNow;
        _context.AddRange(entities);
        _context.SaveChanges();
        return entities;
    }

    public async Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entities)
    {
        foreach (TEntity entity in entities)
            entity.CreatedDate = DateTime.UtcNow;
        await _context.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Querayble();

        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (enableTracking)
            queryable = queryable.AsNoTracking();
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();

        return queryable.Any();
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false,
        bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Querayble();

        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (enableTracking)
            queryable = queryable.AsNoTracking();
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();

        return await queryable.AnyAsync(cancellationToken);
    }

    public TEntity Delete(TEntity entity, bool permanent = false)
    {
        SetEntityAsDeletedAsync(entity, permanent).ConfigureAwait(false);
         _context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false)
    {
        await SetEntityAsDeletedAsync(entity, permanent);
        await _context.SaveChangesAsync();
        return entity;
    }

    public IList<TEntity> DeleteRange(IList<TEntity> entities, bool permanent = false)
    {
        foreach (TEntity entity in entities)
            SetEntityAsDeletedAsync(entity, permanent).ConfigureAwait(false);
        return entities;
    }

    public async Task<IList<TEntity>> DeleteRangeAsync(IList<TEntity> entities, bool permanent = false)
    {
        foreach (TEntity entity in entities)
            await SetEntityAsDeletedAsync(entity, permanent);
        return entities;
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Querayble();

        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);

        return queryable.FirstOrDefault(predicate);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Querayble();

        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public Paginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool withDeleted = false,
        bool enableTracking = true, int index = 0, int size = 10)
    {
        IQueryable<TEntity> queryable = Querayble();

        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (enableTracking)
            queryable = queryable.AsNoTracking();
        if (predicate != null)
            queryable.Where(predicate);
        if (include != null)
            queryable = include(queryable);
        if (orderBy != null)
            queryable = orderBy(queryable);

        return queryable.ToPaginate(index: index, size: size);
    }

    public async Task<Paginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false, bool enableTracking = true, int index = 0, int size = 10,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Querayble();

        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (enableTracking)
            queryable = queryable.AsNoTracking();
        if (predicate != null)
            queryable.Where(predicate);
        if (include != null)
            queryable = include(queryable);
        if (orderBy != null)
            queryable = orderBy(queryable);

        return await queryable.ToPaginateAsync(index: index, size: size, cancellationToken: cancellationToken);
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        _context.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public IList<TEntity> UpdateRange(IList<TEntity> entities)
    {
        foreach (var entity in entities)
            entity.UpdatedDate = DateTime.UtcNow;
        _context.UpdateRange(entities);
        _context.SaveChanges();
        return entities;
    }

    public async Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities)
    {
        foreach (var entity in entities)
            entity.UpdatedDate = DateTime.UtcNow;
        _context.UpdateRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public IQueryable<TEntity> Querayble()
    {
        return _context.Set<TEntity>();
    }
    protected async Task SetEntityAsDeletedAsync(TEntity entity, bool permanent)
    {
        if (!permanent)
        {
            CheckHasEntityHaveOneToOneRelation(entity);
            await setEntityAsSoftDeletedAsync(entity);
        }
        else
        {
            _context.Remove(entity);
        }
    }
    protected async Task SetEntityAsDeletedAsync(IEnumerable<TEntity> entities, bool permanent)
    {
        foreach (TEntity entity in entities)
            await SetEntityAsDeletedAsync(entity, permanent);
    }
    protected void CheckHasEntityHaveOneToOneRelation(TEntity entity)
    {
        bool hasEntityHaveOneToOneRelation =
            _context.Entry(entity).Metadata.GetForeignKeys().All(
                    x =>
                        x.DependentToPrincipal?.IsCollection == true
                        || x.PrincipalToDependent?.IsCollection == true
                        || x.DependentToPrincipal?.ForeignKey.DeclaringEntityType.ClrType == entity.GetType()) == false;
        if (hasEntityHaveOneToOneRelation)
            throw new InvalidOperationException(
                "Entity has one-to-one relationship. Soft Delete causes problems if you try to create entry again by same foreign key."
            );
    }
    private async Task setEntityAsSoftDeletedAsync(IEntityTimeStamps entity)
    {
        if (entity.DeletedDate.HasValue)
            return;

        entity.DeletedDate = DateTime.UtcNow;

        var navigations = _context
            .Entry(entity)
            .Metadata.GetNavigations()
            .Where(x => x is { IsOnDependent: false, ForeignKey.DeleteBehavior: DeleteBehavior.ClientCascade or DeleteBehavior.Cascade })
            .ToList();
        foreach (INavigation? navigation in navigations)
        {
            if (navigation.TargetEntityType.IsOwned())
                continue;
            if (navigation.PropertyInfo == null)
                continue;

            object? navValue = navigation.PropertyInfo.GetValue(entity);
            if (navigation.IsCollection)
            {
                if (navValue == null)
                {
                    IQueryable query = _context.Entry(entity).Collection(navigation.PropertyInfo.Name).Query();
                    navValue = await GetRelationLoaderQuery(query, navigationPropertyType: navigation.PropertyInfo.GetType()).ToListAsync();
                    if (navValue == null)
                        continue;
                }

                foreach (IEntityTimeStamps navValueItem in (IEnumerable)navValue)
                    await setEntityAsSoftDeletedAsync(navValueItem);
            }
            else
            {
                if (navValue == null)
                {
                    IQueryable query = _context.Entry(entity).Reference(navigation.PropertyInfo.Name).Query();
                    navValue = await GetRelationLoaderQuery(query, navigationPropertyType: navigation.PropertyInfo.GetType())
                        .FirstOrDefaultAsync();
                    if (navValue == null)
                        continue;
                }

                await setEntityAsSoftDeletedAsync((IEntityTimeStamps)navValue);
            }
        }

        _context.Update(entity);
    }

    protected IQueryable<object> GetRelationLoaderQuery(IQueryable query, Type navigationPropertyType)
    {
        Type queryProviderType = query.Provider.GetType();
        MethodInfo createQueryMethod =
            queryProviderType.GetMethods().First(m => m is { Name: nameof(query.Provider.CreateQuery), IsGenericMethod: true })
                ?.MakeGenericMethod(navigationPropertyType)
            ?? throw new InvalidOperationException("CreateQuery<TElement> method is not found in IQueryProvider.");
        var queryProviderQuery =
            (IQueryable<object>)createQueryMethod.Invoke(query.Provider, parameters: new object[] { query.Expression })!;
        return queryProviderQuery.Where(x => !((IEntityTimeStamps)x).DeletedDate.HasValue);
    }
}
