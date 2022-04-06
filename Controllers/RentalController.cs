using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services;
using real_estate_web_api.Services.Rentals;

namespace real_estate_web_api.Controllers;

public class RentalController : StandardController<Rental, RentalViewModel, RentalResult>
{
    public RentalController(IRentalManager manager) : base(manager)
    {
    }
}
