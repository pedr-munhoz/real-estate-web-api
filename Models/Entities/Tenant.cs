namespace real_estate_web_api.Models.Entities;

public class Tenant : EntityModel
{
    public virtual string TaxDocument { get; set; } = "";
    public virtual string Address { get; set; } = "";
    public virtual DateTime BirthDate { get; set; }
    public virtual string FirstName { get; set; } = "";
    public virtual string LastName { get; set; } = "";
    public virtual string Mobile { get; set; } = "";
    public virtual double Income { get; set; }
    public virtual bool? InterestedInBuying { get; set; }
}
