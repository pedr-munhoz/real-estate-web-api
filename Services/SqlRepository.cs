using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Services;

public class SqlRepository<T> : IRepository<T>
    where T : class, IEntityModel
{
    private readonly ServerDbContext _dbContext;

    public SqlRepository(ServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<ServiceResult<T>> Create(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult> Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<T>> Find(Func<T, bool> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResult<List<T>>> Retrieve()
    {
        var entities = await _dbContext.Set<T>().Where(x => x.InactivatedAt == null).ToListAsync();

        return new ServiceResult<List<T>>(entities);
    }

    public Task<ServiceResult<T>> Retrieve(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<List<T>>> Search(Func<T, bool> filter, Func<T, bool>? secondaryFilter = null)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<T>> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
