using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services;

namespace real_estate_web_api.Controllers;

public class OwnerController : StandardController<IOwner, OwnerViewModel, OwnerResult>
{
    public OwnerController(IRepository<IOwner> repository) : base(repository)
    {
    }
}
