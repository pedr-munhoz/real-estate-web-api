using Microsoft.EntityFrameworkCore;

namespace real_estate_web_api.Models.Entities.Tenants;

public static class TenantQuery
{
    public static IQueryable<Tenant> IncludePerson(this IQueryable<Tenant> entities)
    {
        return entities.Include(x => x.Person);
    }
}
