namespace real_estate_web_api.Models.Entities.People;

public interface IPerson : IEntityModel, IOwner, IRealtor, ITenant
{
    bool IsOwner { get; set; }
    bool IsRealtor { get; set; }
    bool IsTenant { get; set; }
}
