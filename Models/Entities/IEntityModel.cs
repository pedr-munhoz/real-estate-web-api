namespace real_estate_web_api.Models.Entities;

public interface IEntityModel
{
    long Id { get; set; }
    DateTime CreatedAt { get; set; }
}
