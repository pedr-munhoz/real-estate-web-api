using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.Results;

public class OwnerResult : Result<Owner>
{
    public OwnerResult()
    {
    }

    public OwnerResult(Owner entity) : base(entity)
    {
        Person.TaxDocument = entity.Person.TaxDocument;
        Person.Address = entity.Person.Address;
        Person.BirthDate = entity.Person.BirthDate;
        Person.FirstName = entity.Person.FirstName;
        Person.LastName = entity.Person.LastName;
        Person.Mobile = entity.Person.Mobile;
    }

    public Person Person { get; set; } = new Person();

    public override Result<Owner> Instantiate(Owner entity)
        => new OwnerResult(entity);
}
