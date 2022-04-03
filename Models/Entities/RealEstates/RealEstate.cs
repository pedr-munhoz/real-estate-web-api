using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Enumerations;

namespace real_estate_web_api.Models.Entities.RealEstates;

public class RealEstate : EntityModel, IRealEstate
{
    public string Address { get; set; } = "";
    public BuildingType Type { get; set; }
    public int GrossBuildingArea { get; set; }
    public int Bedrooms { get; set; }
    public int ParkingSpaces { get; set; }
    public bool SaleAvailable { get; set; }
    public double? SaleAmount { get; set; }
    public bool RentAvailable { get; set; }
    public double? RentAmount { get; set; }
    public IOwner Owner { get; set; } = new Owner();
    public IRealtor Realtor { get; set; } = new Realtor();
}
