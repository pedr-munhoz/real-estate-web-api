using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Models.Results;

public class TenantResult : Result<ITenant>, ITenant
{
    public TenantResult()
    {
    }

    public TenantResult(ITenant entity) : base(entity)
    {
        TaxDocument = entity.TaxDocument;
        Address = entity.Address;
        BirthDate = entity.BirthDate;
        FirstName = entity.FirstName;
        LastName = entity.LastName;
        Mobile = entity.Mobile;
        Income = entity.Income;
        InterestedInBuying = entity.InterestedInBuying;
    }

    public string TaxDocument { get; set; } = "";
    public string Address { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Mobile { get; set; } = "";
    public double Income { get; set; }
    public bool? InterestedInBuying { get; set; }

    public override Result<ITenant> Instantiate(ITenant entity)
        => new TenantResult(entity);
}
