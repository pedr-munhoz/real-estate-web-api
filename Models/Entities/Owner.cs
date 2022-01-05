namespace real_state_web_api.Models.Entities;

public class Owner : EntityModel
{
    public virtual string TaxDocument { get; set; } = "";
    public virtual string Address { get; set; } = "";
    public virtual int Age { get; set; }
    public virtual string FirstName { get; set; } = "";
    public virtual string LastName { get; set; } = "";
    public virtual string Mobile { get; set; } = "";
    public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
}
