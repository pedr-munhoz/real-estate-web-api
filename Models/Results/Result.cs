using Newtonsoft.Json;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.Results;

public abstract class Result<T> : IEntityModel
    where T : IEntityModel
{
    protected Result()
    {
    }

    protected Result(T entity)
    {
        Id = entity.Id;
        CreatedAt = entity.CreatedAt;
    }

    public string Id { get; set; } = "";

    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public DateTime? InactivatedAt { get; set; }

    public abstract Result<T> Instantiate(T entity);
}
