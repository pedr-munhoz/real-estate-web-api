using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Services;

public class SqlRepository<T> : IRepository<T>
    where T : class, IEntityModel
{
    protected readonly ServerDbContext _dbContext;

    public SqlRepository(ServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<ServiceResult<T>> Create(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return new ServiceResult<T>(entity);
    }

    public virtual async Task<ServiceResult> Delete(long id)
    {
        var entity = await _dbContext.Set<T>()
            .WhereActive()
            .WhereId(id)
            .FirstOrDefaultAsync();

        if (entity == null)
        {
            var error = new ServiceError($"{typeof(T).Name} not found", $"No {typeof(T).Name} could be located for id: {id}", 404);
            return new ServiceResult(false, error);
        }

        entity.InactivatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return new ServiceResult(true);
    }

    public virtual async Task<ServiceResult<T>> Find(Func<T, bool> expression)
    {
        var entities = await _dbContext.Set<T>()
            .WhereActive()
            .ToListAsync();

        var entity = entities
            .Where(expression)
            .FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError("Entity not found", $"No entity could be located", 404);
            return new ServiceResult<T>(error);
        }

        return new ServiceResult<T>(entity);
    }

    public virtual async Task<ServiceResult<List<T>>> Retrieve()
    {
        var entities = await _dbContext.Set<T>()
            .WhereActive()
            .ToListAsync();

        return new ServiceResult<List<T>>(entities);
    }

    public virtual async Task<ServiceResult<T>> Retrieve(long id)
    {
        var entity = await _dbContext.Set<T>()
            .WhereActive()
            .WhereId(id)
            .FirstOrDefaultAsync();

        if (entity == null)
        {
            var error = new ServiceError($"{typeof(T).Name} not found", $"No {typeof(T).Name} could be located for id: {id}", 404);
            return new ServiceResult<T>(error);
        }

        return new ServiceResult<T>(entity);
    }

    public virtual async Task<ServiceResult<List<T>>> Search(Func<T, bool> filter, Func<T, bool>? secondaryFilter = null)
    {
        var entities = await _dbContext.Set<T>()
            .WhereActive()
            .ToListAsync();

        var searchResult = secondaryFilter == null
            ? entities.Where(filter).ToList()
            : entities.Where(filter).Where(secondaryFilter).ToList();

        return new ServiceResult<List<T>>(searchResult);
    }

    public virtual Task<ServiceResult<T>> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
