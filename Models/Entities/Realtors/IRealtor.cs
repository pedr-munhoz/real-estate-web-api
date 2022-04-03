using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.Entities.Realtors;

public interface IRealtor : IEntityModel
{
    Person Person { get; set; }
}