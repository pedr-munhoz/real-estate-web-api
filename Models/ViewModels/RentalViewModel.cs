using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.ViewModels;

public class RentalViewModel : ViewModel<IRental>, IRental
{
    [Required]
    public long RealEstateId { get; set; }

    [JsonIgnore]
    public RealEstate RealEstate { get; set; } = new RealEstate();

    [Required]
    public long RealtorId { get; set; }

    [JsonIgnore]
    public Realtor Realtor { get; set; } = new Realtor();

    [Required]
    public long TenantId { get; set; }

    [JsonIgnore]
    public Tenant Tenant { get; set; } = new Tenant();

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public int Duration { get; set; }

    [JsonIgnore]
    public DateTime EndDate { get; set; }

    public double MonthlyAmount { get; set; }

    public override Rental Map()
    {
        return new Rental
        {
            Id = Id,
            StartDate = StartDate,
            EndDate = StartDate.AddMonths(Duration),
            MonthlyAmount = MonthlyAmount,
            RealEstate = new RealEstate { Id = RealEstateId },
            Realtor = new Realtor { Id = RealtorId },
            Tenant = new Tenant { Id = TenantId },
        };
    }
}
