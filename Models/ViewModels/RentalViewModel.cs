using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public class RentalViewModel : Rental, ViewModel<Rental>
{
    [Required]
    public string RealEstateId { get; set; } = "";

    [JsonIgnore]
    public override RealEstate RealEstate { get; set; } = new RealEstate();

    [Required]
    public string RealtorId { get; set; } = "";

    [JsonIgnore]
    public override Realtor Realtor { get; set; } = new Realtor();

    [Required]
    public string TenantId { get; set; } = "";

    [JsonIgnore]
    public override Tenant Tenant { get; set; } = new Tenant();

    [Required]
    public override DateTime StartDate { get; set; }

    [Required]
    public int Duration { get; set; }

    [JsonIgnore]
    public override DateTime EndDate { get; set; }

    [JsonIgnore]
    public override DateTime CreatedAt { get; set; } = DateTime.Now;

    [JsonIgnore]
    public override DateTime? InactivatedAt { get; set; }

    public Rental Map()
    {
        return new Rental
        {
            StartDate = StartDate,
            EndDate = StartDate.AddMonths(Duration),
            MonthlyAmount = MonthlyAmount,
            RealEstate = new RealEstate { Id = RealEstateId },
            Realtor = new Realtor { Id = RealtorId },
            Tenant = new Tenant { Id = TenantId },
        };
    }
}
