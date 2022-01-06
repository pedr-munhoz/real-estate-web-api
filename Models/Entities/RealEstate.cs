using real_estate_web_api.Models.Enumerations;

namespace real_estate_web_api.Models.Entities;

public class RealEstate : EntityModel
{
    public virtual string Address { get; set; } = "";
    public virtual BuildingType Type { get; set; }
    public virtual int GrossBuildingArea { get; set; }
    public virtual int Bedrooms { get; set; }
    public virtual int ParkingSpaces { get; set; }
    public virtual bool SaleAvailable { get; set; }
    public virtual double? SaleAmount { get; set; }
    public virtual bool RentAvailable { get; set; }
    public virtual double? RentAmount { get; set; }
}
