using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.Results;

public class RentalDeepResult : Result<Rental>
{
    public RentalDeepResult()
    {
    }

    public RentalDeepResult(Rental entity) : base(entity)
    {
        StartDate = entity.StartDate;
        EndDate = entity.EndDate;
        MonthlyAmount = entity.MonthlyAmount;
        RealEstate = entity.RealEstate;
        Realtor = entity.Realtor;
        Tenant = entity.Tenant;
    }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double MonthlyAmount { get; set; }
    public RealEstate RealEstate { get; set; } = new RealEstate();
    public Realtor Realtor { get; set; } = new Realtor();
    public Tenant Tenant { get; set; } = new Tenant();

    public override Result<Rental> Instantiate(Rental entity)
        => new RentalDeepResult(entity);
}
