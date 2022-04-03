using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.Entities.Rentals;

public interface IRental : IEntityModel
{
    DateTime StartDate { get; set; }
    DateTime EndDate { get; set; }
    double MonthlyAmount { get; set; }
    IRealEstate RealEstate { get; set; }
    IRealtor Realtor { get; set; }
    ITenant Tenant { get; set; }
}
