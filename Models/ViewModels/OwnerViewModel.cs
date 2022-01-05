using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using real_state_web_api.Models.Entities;

namespace real_state_web_api.Models.ViewModels;

public class OwnerViewModel : Owner, ViewModel<Owner>
{
    [Required]
    public override string TaxDocument { get; set; } = "";

    [Required]
    public override string Address { get; set; } = "";

    [Required]
    public override int Age { get; set; }

    [Required]
    public override string FirstName { get; set; } = "";

    [Required]
    public override string LastName { get; set; } = "";

    [Required]
    public override string Mobile { get; set; } = "";

    [JsonIgnore]
    public override DateTime CreatedAt { get; set; } = DateTime.Now;

    public Owner Map() => this;
}
