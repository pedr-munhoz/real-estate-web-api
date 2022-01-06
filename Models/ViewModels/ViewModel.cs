using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public interface ViewModel<T>
    where T : EntityModel
{
    T Map();
}
