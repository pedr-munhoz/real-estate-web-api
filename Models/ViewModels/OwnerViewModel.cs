using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.ViewModels;

public class OwnerViewModel : ViewModel<IOwner>, IOwner
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

    public override IOwner Map()
    {
        return new Person
        {
            IsOwner = true,
            Id = Id,
            TaxDocument = TaxDocument,
            Address = Address,
            BirthDate = BirthDate,
            FirstName = FirstName,
            LastName = LastName,
            Mobile = Mobile,
        };
    }
}
