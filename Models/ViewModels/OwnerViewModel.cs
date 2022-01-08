using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public class OwnerViewModel : Owner, ViewModel<Owner>
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

    [JsonIgnore]
    public override DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public override DateTime? InactivatedAt { get; set; }

    public Owner Map()
    {
        return new Owner
        {
            TaxDocument = TaxDocument,
            Address = Address,
            BirthDate = BirthDate,
            FirstName = FirstName,
            LastName = LastName,
            Mobile = Mobile,
        };
    }
}
