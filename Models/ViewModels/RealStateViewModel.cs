using real_state_web_api.Models.Entities;

namespace real_state_web_api.Models.ViewModels;

public class RealStateViewModel : RealState, ViewModel<RealState>
{
    public RealState Map() => this;
}
