namespace real_estate_web_api.Models.Entities.Realtors;

public class Realtor : EntityModel, IRealtor
{
    public string TaxDocument { get; set; } = "";
    public string Address { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Mobile { get; set; } = "";
}
