using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Realtors;

namespace real_estate_web_api.Models.ViewModels;

public class RealtorViewModel : ViewModel<Realtor>
{
    [Required]
    public PersonViewModel Person { get; set; } = new PersonViewModel();

    public override Realtor Map()
    {
        return new Realtor
        {
            Id = Id,
            Person = Person.Map(),
        };
    }
}
