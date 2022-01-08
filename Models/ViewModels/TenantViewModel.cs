using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public class TenantViewModel : Tenant, ViewModel<Tenant>
{
    [Required]
    public override string TaxDocument { get; set; } = "";

    [Required]
    public override string Address { get; set; } = "";

    [Required]
    public override DateTime BirthDate { get; set; }

    [Required]
    public override string FirstName { get; set; } = "";

    [Required]
    public override string LastName { get; set; } = "";

    [Required]
    public override string Mobile { get; set; } = "";

    [Range(0, Double.PositiveInfinity)]
    public override double Income { get; set; }

    [JsonIgnore]
    public override DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public override DateTime? InactivatedAt { get; set; }

    public Tenant Map()
    {
        return new Tenant
        {
            TaxDocument = TaxDocument,
            Address = Address,
            BirthDate = BirthDate,
            FirstName = FirstName,
            LastName = LastName,
            Mobile = Mobile,
            Income = Income,
            InterestedInBuying = InterestedInBuying,
        };
    }
}
