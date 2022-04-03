using System.Linq;
using System.Linq.Expressions;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Services;

public class ListRepository<T> : IRepository<T>
    where T : IEntityModel
{
    private static List<T> _data = new List<T>();

    public async Task<ServiceResult<T>> Create(T entity)
    {
        await Task.CompletedTask;

        entity.Id = Guid.NewGuid().ToString();
        _data.Add(entity);

        return new ServiceResult<T>(entity);
    }

    public async Task<ServiceResult> Delete(string id)
    {
        await Task.CompletedTask;

        var entity = _data.Where(x => x.Id == id).FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError($"{typeof(T).Name} not found", $"No {typeof(T).Name} could be located for id: {id}", 404);
            return new ServiceResult(false, error);
        }

        _data.Remove(entity);

        return new ServiceResult(true);
    }

    public async Task<ServiceResult<List<T>>> Search(Func<T, bool> filter, Func<T, bool>? secondaryFilter = null)
    {
        await Task.CompletedTask;

        var result = secondaryFilter == null
            ? new ServiceResult<List<T>>(_data.Where(filter).ToList())
            : new ServiceResult<List<T>>(_data.Where(filter).Where(secondaryFilter).ToList());

        return result;
    }

    public async Task<ServiceResult<List<T>>> Retrieve()
    {
        await Task.CompletedTask;

        return new ServiceResult<List<T>>(_data);
    }

    public async Task<ServiceResult<T>> Retrieve(string id)
    {
        await Task.CompletedTask;

        var entity = _data.Where(x => x.Id == id).FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError($"{typeof(T).Name} not found", $"No {typeof(T).Name} could be located for id: {id}", 404);
            return new ServiceResult<T>(error);
        }

        return new ServiceResult<T>(entity);
    }

    public async Task<ServiceResult<T>> Update(T newEntity)
    {
        await Task.CompletedTask;

        var entity = _data.Where(x => x.Id == newEntity.Id).FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError("Entity not found", $"No entity could be located for id: {newEntity.Id}", 404);
            return new ServiceResult<T>(error);
        }

        _data.Remove(entity);
        _data.Add(newEntity);

        return new ServiceResult<T>(newEntity);
    }

    public async Task<ServiceResult<T>> Find(Func<T, bool> expression)
    {
        await Task.CompletedTask;

        var entity = _data.Where(expression).FirstOrDefault();
        if (entity == null)
        {
            var error = new ServiceError("Entity not found", $"No entity could be located", 404);
            return new ServiceResult<T>(error);
        }

        return new ServiceResult<T>(entity);
    }
}
