namespace real_estate_web_api.Models.Entities.Tenants;

public class Tenant : EntityModel, ITenant
{
    public string TaxDocument { get; set; } = "";
    public string Address { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Mobile { get; set; } = "";
    public double Income { get; set; }
    public bool? InterestedInBuying { get; set; }
}
