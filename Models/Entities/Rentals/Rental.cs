using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.Entities.Rentals;

public class Rental : EntityModel, IRental
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double MonthlyAmount { get; set; }
    public RealEstate RealEstate { get; set; } = new RealEstate();
    public Realtor Realtor { get; set; } = new Realtor();
    public Tenant Tenant { get; set; } = new Tenant();
}
