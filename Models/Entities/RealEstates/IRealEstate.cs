using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Enumerations;

namespace real_estate_web_api.Models.Entities.RealEstates;

public interface IRealEstate : IEntityModel
{
    string Address { get; set; }
    BuildingType Type { get; set; }
    int GrossBuildingArea { get; set; }
    int Bedrooms { get; set; }
    int ParkingSpaces { get; set; }
    bool SaleAvailable { get; set; }
    double? SaleAmount { get; set; }
    bool RentAvailable { get; set; }
    double? RentAmount { get; set; }
    IOwner Owner { get; set; }
    IRealtor Realtor { get; set; }
}
