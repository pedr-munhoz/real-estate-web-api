using System.ComponentModel.DataAnnotations;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public class RealtorViewModel : Realtor, ViewModel<Realtor>
{
    [Required]
    public override string TaxDocument { get; set; } = "";

    [Required]
    public override string FirstName { get; set; } = "";

    [Required]
    public override string LastName { get; set; } = "";

    [Required]
    public override string Mobile { get; set; } = "";

    public Realtor Map() => this;
}
