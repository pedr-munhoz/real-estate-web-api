using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.Entities.Owners
{
    public class Owner : EntityModel, IOwner
    {
        public IPerson Person { get; set; } = new Person();
    }
}