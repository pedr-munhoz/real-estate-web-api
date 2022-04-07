using Microsoft.EntityFrameworkCore;

namespace real_estate_web_api.Models.Entities.Realtors;

public static class RealtorQuery
{
    public static IQueryable<Realtor> IncludePerson(this IQueryable<Realtor> entities)
    {
        return entities.Include(x => x.Person);
    }
}
