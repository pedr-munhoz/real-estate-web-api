using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities;
using real_estate_web_api.Models.Enumerations;

namespace real_estate_web_api.Models.ViewModels;

public class RealEstateViewModel : RealEstate, ViewModel<RealEstate>
{
    [Required]
    public override string Address { get; set; } = "";

    [Required]
    public override BuildingType Type { get; set; }

    [Required]
    [Range(1, 9999)]
    public override int GrossBuildingArea { get; set; }

    [Required]
    [Range(1, 999)]
    public override int Bedrooms { get; set; }

    [Required]
    [Range(1, 999)]
    public override int ParkingSpaces { get; set; }

    [Range(0, Double.PositiveInfinity)]
    public override double? SaleAmount { get; set; }

    [Range(0, Double.PositiveInfinity)]
    public override double? RentAmount { get; set; }

    [JsonIgnore]
    public override DateTime CreatedAt { get; set; } = DateTime.Now;

    [JsonIgnore]
    public override DateTime? InactivatedAt { get; set; }

    public RealEstate Map()
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
