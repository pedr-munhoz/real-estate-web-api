using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.Results;

public class RentalResult : Result<IRental>, IRental
{
    public RentalResult(IRental entity) : base(entity)
    {
        StartDate = entity.StartDate;
        EndDate = entity.EndDate;
        MonthlyAmount = entity.MonthlyAmount;
        RealEstateId = entity.RealEstate?.Id;
        RealtorId = entity.Realtor?.Id;
        TenantId = entity.Tenant?.Id;
    }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double MonthlyAmount { get; set; }

    [JsonIgnore]
    public IRealEstate RealEstate { get; set; } = new RealEstate();
    public string? RealEstateId { get; set; }

    [JsonIgnore]
    public IRealtor Realtor { get; set; } = new Realtor();
    public string? RealtorId { get; set; }

    [JsonIgnore]
    public ITenant Tenant { get; set; } = new Tenant();
    public string? TenantId { get; set; }
}
