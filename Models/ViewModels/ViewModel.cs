using Newtonsoft.Json;
using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.ViewModels;

public abstract class ViewModel<T> : IEntityModel
    where T : IEntityModel
{
    public string Id { get; set; } = "";

    [JsonIgnore]
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public DateTime? InactivatedAt { get; set; }

    public abstract T Map();
}
