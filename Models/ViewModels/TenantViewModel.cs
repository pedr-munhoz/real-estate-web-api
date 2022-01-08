using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.ViewModels;

public class TenantViewModel : ViewModel<ITenant>, ITenant
{
    [Required]
    public string TaxDocument { get; set; } = "";

    [Required]
    public string Address { get; set; } = "";

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public string FirstName { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    [Required]
    public string Mobile { get; set; } = "";

    [Range(0, Double.PositiveInfinity)]
    public double Income { get; set; }
    public bool? InterestedInBuying { get; set; }

    public override ITenant Map()
    {
        return new Person
        {
            IsTenant = true,
            Id = Id,
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
