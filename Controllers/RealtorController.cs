using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services;

namespace real_estate_web_api.Controllers;

public class RealtorController : StandardController<IRealtor, RealtorViewModel, RealtorResult>
{
    public RealtorController(IRepository<IRealtor> repository) : base(repository)
    {
    }
}
