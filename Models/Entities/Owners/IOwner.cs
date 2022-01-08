namespace real_estate_web_api.Models.Entities.Owners;

public interface IOwner : IEntityModel
{
    string TaxDocument { get; set; }
    string Address { get; set; }
    DateTime BirthDate { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Mobile { get; set; }
}
