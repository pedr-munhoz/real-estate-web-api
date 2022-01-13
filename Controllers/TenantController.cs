using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services;

namespace real_estate_web_api.Controllers;

public class TenantController : StandardController<ITenant, TenantViewModel, TenantResult>
{
    public TenantController(IManager<ITenant> manager) : base(manager)
    {
    }
}
