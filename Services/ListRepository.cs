using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Services;

public class ListRepository<T> : IRepository<T>
    where T : IEntityModel
{
    private static List<T> _data = new List<T>();

    public async Task<ServiceResult<T>> Create(T entity)
    {
        await Task.CompletedTask;

        entity.Id = _data.Count;
        _data.Add(entity);

        return new ServiceResult<T>(entity);
    }

    public async Task<ServiceResult> Delete(long id)
    {
        await Task.CompletedTask;

        var entity = _data.Where(x => x.Id == id).FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError("not found", $"entity not found for id: {id}", 404);
            return new ServiceResult(false, error);
        }

        _data.Remove(entity);

        return new ServiceResult(true);
    }

    public async Task<ServiceResult<List<T>>> Retrieve()
    {
        await Task.CompletedTask;

        return new ServiceResult<List<T>>(_data);
    }

    public async Task<ServiceResult<T>> Retrieve(long id)
    {
        await Task.CompletedTask;

        var entity = _data.Where(x => x.Id == id).FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError("not found", $"entity not found for id: {id}", 404);
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
            var error = new ServiceError("not found", $"entity not found for id: {newEntity.Id}", 404);
            return new ServiceResult<T>(error);
        }

        _data.Remove(entity);
        _data.Add(newEntity);

        return new ServiceResult<T>(newEntity);
    }
}
