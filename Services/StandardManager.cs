using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Services;
public class StandardManager<T> : IManager<T>
    where T : IEntityModel
{
    protected readonly IRepository<T> _repository;

    public StandardManager(IRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<ServiceResult<T>> Create(T entity)
    {
        var result = await _repository.Create(entity);

        return result;
    }

    public virtual async Task<ServiceResult> Delete(long id)
    {
        var result = await _repository.Delete(id);

        return result;
    }

    public virtual async Task<ServiceResult<List<T>>> Retrieve()
    {
        var result = await _repository.Retrieve();

        return result;
    }

    public virtual async Task<ServiceResult<T>> Retrieve(long id)
    {
        var result = await _repository.Retrieve(id);

        return result;
    }

    public virtual async Task<ServiceResult<List<T>>> Search(Func<T, bool> expression)
    {
        var result = await _repository.Search(expression);

        return result;
    }

    public virtual async Task<ServiceResult<T>> Update(T entity)
    {
        var result = await _repository.Update(entity);

        return result;
    }
}
