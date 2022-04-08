namespace real_estate_web_api.Models.Entities;

public static class EntityModelQuery
{
    public static IQueryable<T> WhereActive<T>(this IQueryable<T> entities)
        where T : IEntityModel
    {
        return entities.Where(x => x.InactivatedAt == null);
    }

    public static IQueryable<T> WhereId<T>(this IQueryable<T> entities, long id)
        where T : IEntityModel
    {
        return entities.Where(x => x.Id == id);
    }
}
