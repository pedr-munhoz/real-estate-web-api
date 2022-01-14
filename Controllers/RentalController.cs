using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services;

namespace real_estate_web_api.Controllers;

public class RentalController : StandardController<IRental, RentalViewModel, RentalResult>
{
    public RentalController(IManager<IRental> manager) : base(manager)
    {
    }
}
