using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public class RealStateViewModel : RealState, ViewModel<RealState>
{
    public RealState Map() => this;
}
