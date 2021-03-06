using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.ViewModels;

public class OwnerViewModel : ViewModel<Owner>
{
    [Required]
    public PersonViewModel Person { get; set; } = new PersonViewModel();

    public override Owner Map()
    {
        return new Owner
        {
            Id = Id,
            Person = Person.Map(),
        };
    }
}
