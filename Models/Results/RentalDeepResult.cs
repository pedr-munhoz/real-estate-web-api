using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Models.Results;

public class RentalDeepResult : Result<IRental>, IRental
{
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
    public IRealEstate RealEstate { get; set; }
    public IRealtor Realtor { get; set; }
    public ITenant Tenant { get; set; }
}
