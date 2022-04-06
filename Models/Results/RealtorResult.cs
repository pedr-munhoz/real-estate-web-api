using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Realtors;

namespace real_estate_web_api.Models.Results;

public class RealtorResult : Result<Realtor>
{
    public RealtorResult()
    {
    }

    public RealtorResult(Realtor entity) : base(entity)
    {
        Person.TaxDocument = entity.Person.TaxDocument;
        Person.Address = entity.Person.Address;
        Person.BirthDate = entity.Person.BirthDate;
        Person.FirstName = entity.Person.FirstName;
        Person.LastName = entity.Person.LastName;
        Person.Mobile = entity.Person.Mobile;
    }

    public Person Person { get; set; } = new Person();

    public override Result<Realtor> Instantiate(Realtor entity)
        => new RealtorResult(entity);
}
