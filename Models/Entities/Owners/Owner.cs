using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.Entities.Owners
{
    public class Owner : EntityModel
    {
        public Person Person { get; set; } = new Person();
        public long PersonId { get; set; }
    }
}