using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public class RealEstateViewModel : RealEstate, ViewModel<RealEstate>
{
    public RealEstate Map() => this;
}
