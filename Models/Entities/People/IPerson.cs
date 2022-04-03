namespace real_estate_web_api.Models.Entities.People;

public interface IPerson : IEntityModel
{
    string TaxDocument { get; set; }
    string Address { get; set; }
    DateTime BirthDate { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Mobile { get; set; }
}
