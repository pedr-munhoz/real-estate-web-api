using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.Entities.Realtors
{
    public class Realtor : EntityModel, IRealtor
    {
        public Person Person { get; set; } = new Person();
    }
}