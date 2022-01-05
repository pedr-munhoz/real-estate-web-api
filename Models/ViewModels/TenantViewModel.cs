using real_state_web_api.Models.Entities;

namespace real_state_web_api.Models.ViewModels;

public class TenantViewModel : Tenant, ViewModel<Tenant>
{
    public Tenant Map() => this;
}
