using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public class RentalViewModel : Rental, ViewModel<Rental>
{
    public Rental Map() => this;

}
