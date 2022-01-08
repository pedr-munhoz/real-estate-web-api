using real_estate_web_api.Models.Entities.Owners;

namespace real_estate_web_api.Models.Results;

public class OwnerResult : Result<IOwner>, IOwner
{
    public OwnerResult()
    {
    }

    public OwnerResult(IOwner entity) : base(entity)
    {
        TaxDocument = entity.TaxDocument;
        Address = entity.Address;
        BirthDate = entity.BirthDate;
        FirstName = entity.FirstName;
        LastName = entity.LastName;
        Mobile = entity.Mobile;
    }

    public string TaxDocument { get; set; } = "";
    public string Address { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Mobile { get; set; } = "";

    public override Result<IOwner> Instantiate(IOwner entity)
        => new OwnerResult(entity);
}
