namespace real_estate_web_api.Models.Entities.People;

public interface ITenant : IPerson
{
    double Income { get; set; }
    bool? InterestedInBuying { get; set; }
}
