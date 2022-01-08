namespace real_estate_web_api.Models.Entities;

public class Rental : EntityModel
{
    public virtual DateTime StartDate { get; set; }
    public virtual DateTime EndDate { get; set; }
    public virtual double MonthlyAmount { get; set; }
    public virtual RealEstate RealEstate { get; set; } = new RealEstate();
    public virtual Realtor Realtor { get; set; } = new Realtor();
    public virtual Tenant Tenant { get; set; } = new Tenant();
}
