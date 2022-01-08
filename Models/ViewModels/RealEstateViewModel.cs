using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Enumerations;

namespace real_estate_web_api.Models.ViewModels;

public class RealEstateViewModel : ViewModel<IRealEstate>, IRealEstate
{
    [Required]
    public string Address { get; set; } = "";

    [Required]
    public BuildingType Type { get; set; }

    [Required]
    [Range(1, 9999)]
    public int GrossBuildingArea { get; set; }

    [Required]
    [Range(1, 999)]
    public int Bedrooms { get; set; }

    [Required]
    [Range(1, 999)]
    public int ParkingSpaces { get; set; }

    [Range(0, Double.PositiveInfinity)]
    public double? SaleAmount { get; set; }

    [Range(0, Double.PositiveInfinity)]
    public double? RentAmount { get; set; }

    public bool SaleAvailable { get; set; }

    public bool RentAvailable { get; set; }

    public override RealEstate Map()
    {
        return new RealEstate
        {
            Address = Address,
            Type = Type,
            GrossBuildingArea = GrossBuildingArea,
            Bedrooms = Bedrooms,
            ParkingSpaces = ParkingSpaces,
            SaleAvailable = SaleAvailable,
            SaleAmount = SaleAmount,
            RentAvailable = RentAvailable,
            RentAmount = RentAmount,
        };
    }
}
