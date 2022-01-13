using System.Linq.Expressions;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Services;

public interface IRepository<T>
    where T : IEntityModel
{
    Task<ServiceResult<T>> Create(T entity);
    Task<ServiceResult<List<T>>> Retrieve();
    Task<ServiceResult<T>> Retrieve(string id);
    Task<ServiceResult<List<T>>> Search(Func<T, bool> expression);
    Task<ServiceResult<T>> Find(Func<T, bool> expression);
    Task<ServiceResult<T>> Update(T entity);
    Task<ServiceResult> Delete(string id);
}
