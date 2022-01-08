namespace real_estate_web_api.Models.Entities.Realtors;

public interface IRealtor : IEntityModel
{
    string TaxDocument { get; set; }
    string Address { get; set; }
    DateTime BirthDate { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Mobile { get; set; }
}