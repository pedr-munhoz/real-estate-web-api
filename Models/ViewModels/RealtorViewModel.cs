using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.Realtors;

namespace real_estate_web_api.Models.ViewModels;

public class RealtorViewModel : ViewModel<IRealtor>, IRealtor
{
    [Required]
    public string TaxDocument { get; set; } = "";

    [Required]
    public string FirstName { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    [Required]
    public string Mobile { get; set; } = "";

    public string Address { get; set; } = "";

    public DateTime BirthDate { get; set; }

    public override Realtor Map()
    {
        return new Realtor
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
