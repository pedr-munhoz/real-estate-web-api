using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Rentals;

namespace real_estate_web_api.Models.Results;

public class RentalDeepResult : Result<IRental>, IRental
{
    public RentalDeepResult()
    {
    }

    public RentalDeepResult(IRental entity) : base(entity)
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
    public IRealEstate RealEstate { get; set; } = new RealEstate();
    public IRealtor Realtor { get; set; } = new Person();
    public ITenant Tenant { get; set; } = new Person();

    public override Result<IRental> Instantiate(IRental entity)
        => new RentalDeepResult(entity);
}
