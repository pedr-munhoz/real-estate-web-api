using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.Entities.Owners;

public interface IOwner : IEntityModel
{
    IPerson Person { get; set; }
}
