using real_estate_web_api.Models.Entities.Tenants;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services;
using real_estate_web_api.Services.Tenants;

namespace real_estate_web_api.Controllers;

public class TenantController : StandardController<Tenant, TenantViewModel, TenantResult>
{
    public TenantController(ITenantManager manager) : base(manager)
    {
    }
}
