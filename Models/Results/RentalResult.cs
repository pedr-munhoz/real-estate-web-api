using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.Results;

public class RentalResult : Result<Rental>
{
    public RentalResult()
    {
    }

    public RentalResult(Rental entity) : base(entity)
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
    public RealEstate RealEstate { get; set; } = new RealEstate();
    public long? RealEstateId { get; set; }

    [JsonIgnore]
    public Realtor Realtor { get; set; } = new Realtor();
    public long? RealtorId { get; set; }

    [JsonIgnore]
    public Tenant Tenant { get; set; } = new Tenant();
    public long? TenantId { get; set; }

    public override Result<Rental> Instantiate(Rental entity)
        => new RentalResult(entity);
}
