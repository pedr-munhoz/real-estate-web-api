using real_estate_web_api.Models.Entities;

namespace real_estate_web_api.Models.Results;

public class ListResult<T>
    where T : IEntityModel
{
    public ListResult(List<Result<T>> entities)
    {
        Items = entities;
        Count = entities.Count;
    }

    public List<Result<T>> Items { get; set; }
    public int Count { get; set; }
}
