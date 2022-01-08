using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Services;

public interface IRepository<T>
    where T : IEntityModel
{
    ServiceResult<T> Create(T entity);
    ServiceResult<List<T>> Retrieve();
    ServiceResult<T> Retrieve(string id);
    ServiceResult<T> Update(T entity);
    ServiceResult Delete(string id);
}
