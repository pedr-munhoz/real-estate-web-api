using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public class RealtorViewModel : Realtor, ViewModel<Realtor>
{
    public Realtor Map() => this;
}
