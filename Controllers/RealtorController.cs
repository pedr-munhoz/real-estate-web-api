using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services;
using real_estate_web_api.Services.Realtors;

namespace real_estate_web_api.Controllers;

public class RealtorController : StandardController<IRealtor, RealtorViewModel, RealtorResult>
{
    public RealtorController(IRealtorManager manager) : base(manager)
    {
    }
}
