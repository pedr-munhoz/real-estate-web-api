namespace real_estate_web_api.Models.Entities;

public abstract class EntityModel
{
    public EntityModel() { }

    public virtual string Id { get; set; } = "";
    public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
    public virtual DateTime? InactivatedAt { get; set; }
}
