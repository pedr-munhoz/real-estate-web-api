using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Services;

public class ListRepository<T> : IRepository<T>
    where T : IEntityModel
{
    private List<T> _data = new List<T>();

    public ServiceResult<T> Create(T entity)
    {
        entity.Id = Guid.NewGuid().ToString();
        _data.Add(entity);

        return new ServiceResult<T>(entity);
    }

    public ServiceResult Delete(string id)
    {
        var entity = _data.Where(x => x.Id == id).FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError("not found", $"entity not found for id: {id}");
            return new ServiceResult(false, error);
        }

        _data.Remove(entity);

        return new ServiceResult(true);
    }

    public ServiceResult<List<T>> Retrieve()
    {
        return new ServiceResult<List<T>>(_data);
    }

    public ServiceResult<T> Retrieve(string id)
    {
        var entity = _data.Where(x => x.Id == id).FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError("not found", $"entity not found for id: {id}");
            return new ServiceResult<T>(error);
        }

        return new ServiceResult<T>(entity);
    }

    public ServiceResult<T> Update(T newEntity)
    {
        var entity = _data.Where(x => x.Id == newEntity.Id).FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError("not found", $"entity not found for id: {newEntity.Id}");
            return new ServiceResult<T>(error);
        }

        _data.Remove(entity);
        _data.Add(newEntity);

        return new ServiceResult<T>(newEntity);
    }
}
