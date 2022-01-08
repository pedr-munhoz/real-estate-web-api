namespace real_estate_web_api.Models.Entities.Owners;

public class Owner : EntityModel, IOwner
{
    public string TaxDocument { get; set; } = "";
    public string Address { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Mobile { get; set; } = "";
}
