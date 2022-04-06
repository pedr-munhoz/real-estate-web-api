namespace real_estate_web_api.Models.Entities;

public abstract class EntityModel : IEntityModel
{
    public EntityModel() { }

    public virtual long Id { get; set; }
    public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
    public virtual DateTime? InactivatedAt { get; set; }
}
