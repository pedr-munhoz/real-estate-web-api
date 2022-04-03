using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Realtors;

namespace real_estate_web_api.Models.Results;

public class RealtorResult : Result<IRealtor>, IRealtor
{
    public RealtorResult()
    {
    }

    public RealtorResult(IRealtor entity) : base(entity)
    {
        Person.TaxDocument = entity.Person.TaxDocument;
        Person.Address = entity.Person.Address;
        Person.BirthDate = entity.Person.BirthDate;
        Person.FirstName = entity.Person.FirstName;
        Person.LastName = entity.Person.LastName;
        Person.Mobile = entity.Person.Mobile;
    }

    public IPerson Person { get; set; } = new Person();

    public override Result<IRealtor> Instantiate(IRealtor entity)
        => new RealtorResult(entity);
}
