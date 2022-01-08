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
}
