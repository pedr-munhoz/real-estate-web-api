using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.ViewModels;

public class TenantViewModel : ViewModel<ITenant>
{
    [Required]
    public PersonViewModel Person { get; set; } = new PersonViewModel();

    [Range(0, Double.PositiveInfinity)]
    public double Income { get; set; }
    public bool? InterestedInBuying { get; set; }

    public override ITenant Map()
    {
        return new Tenant
        {
            Id = Id,
            Income = Income,
            InterestedInBuying = InterestedInBuying,
            Person = Person.Map(),
        };
    }
}
