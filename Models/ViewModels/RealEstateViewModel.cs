using System.ComponentModel.DataAnnotations;
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

    public RealEstate Map() => this;
}
