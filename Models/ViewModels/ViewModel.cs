using real_state_web_api.Models.Entities;

namespace real_state_web_api.Models.ViewModels;

public interface ViewModel<T>
    where T : EntityModel
{
    T Map();
}
