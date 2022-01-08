using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;

namespace real_estate_web_api.Models.Entities.Rentals;

public class Rental : EntityModel, IRental
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double MonthlyAmount { get; set; }
    public IRealEstate RealEstate { get; set; } = new RealEstate();
    public IRealtor Realtor { get; set; } = new Person();
    public ITenant Tenant { get; set; } = new Person();
}
