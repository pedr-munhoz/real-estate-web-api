using Microsoft.EntityFrameworkCore;

namespace real_estate_web_api.Models.Entities.Owners;

public static class OwnerQuery
{
    public static IQueryable<Owner> IncludePerson(this IQueryable<Owner> entities)
    {
        return entities.Include(x => x.Person);
    }
}