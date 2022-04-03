using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.Entities.Tenants
{
    public class Tenant : EntityModel, ITenant
    {
        public IPerson Person { get; set; } = new Person();
        public double Income { get; set; }
        public bool? InterestedInBuying { get; set; }
    }
}