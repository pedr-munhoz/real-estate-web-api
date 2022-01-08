using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.Entities.Rentals;

public class Rental : EntityModel, IRental
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double MonthlyAmount { get; set; }
    public IRealEstate RealEstate { get; set; } = new RealEstate();
    public IRealtor Realtor { get; set; } = new Realtor();
    public ITenant Tenant { get; set; } = new Tenant();
}
