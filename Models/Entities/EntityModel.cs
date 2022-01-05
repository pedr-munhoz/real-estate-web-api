namespace real_state_web_api.Models.Entities;

public abstract class EntityModel
{
    public EntityModel() { }

    public virtual string Id { get; set; } = "";
}
