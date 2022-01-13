using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services;

namespace real_estate_web_api.Controllers;

public class RealEstateController : StandardController<IRealEstate, RealEstateViewModel, RealEstateResult>
{
    public RealEstateController(IRepository<IRealEstate> repository) : base(repository)
    {
    }
}
