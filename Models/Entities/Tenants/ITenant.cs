using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.Entities.Tenants;

public interface ITenant : IEntityModel
{
    Person Person { get; set; }
    double Income { get; set; }
    bool? InterestedInBuying { get; set; }
}
