using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Services;

public interface IRepository<T>
    where T : IEntityModel
{
    Task<ServiceResult<T>> Create(T entity);
    Task<ServiceResult<List<T>>> Retrieve();
    Task<ServiceResult<T>> Retrieve(long id);
    Task<ServiceResult<T>> Update(T entity);
    Task<ServiceResult> Delete(long id);
}
