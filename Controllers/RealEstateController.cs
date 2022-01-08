using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;

namespace real_estate_web_api.Controllers;

public class RealEstateController : StandardController<IRealEstate, RealEstateViewModel, RealEstateResult>
{

}
