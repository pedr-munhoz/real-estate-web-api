namespace real_estate_web_api.Models.Entities;

public interface IEntityModel
{
    string Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? InactivatedAt { get; set; }
}
