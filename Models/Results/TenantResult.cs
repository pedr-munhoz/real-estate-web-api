using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.Results;

public class TenantResult : Result<Tenant>
{
    public TenantResult()
    {
    }

    public TenantResult(Tenant entity) : base(entity)
    {
        Person.TaxDocument = entity.Person.TaxDocument;
        Person.Address = entity.Person.Address;
        Person.BirthDate = entity.Person.BirthDate;
        Person.FirstName = entity.Person.FirstName;
        Person.LastName = entity.Person.LastName;
        Person.Mobile = entity.Person.Mobile;
        Income = entity.Income;
        InterestedInBuying = entity.InterestedInBuying;
    }

    public double Income { get; set; }
    public bool? InterestedInBuying { get; set; }
    public Person Person { get; set; } = new Person();

    public override Result<Tenant> Instantiate(Tenant entity)
        => new TenantResult(entity);
}
