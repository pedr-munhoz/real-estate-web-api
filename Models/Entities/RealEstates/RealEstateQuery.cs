using Microsoft.EntityFrameworkCore;

namespace real_estate_web_api.Models.Entities.RealEstates;

public static class RealEstateQuery
{
    public static IQueryable<RealEstate> IncludeOwner(this IQueryable<RealEstate> entities)
    {
        return entities.Include(x => x.Owner);
    }

    public static IQueryable<RealEstate> IncludeRealtor(this IQueryable<RealEstate> entities)
    {
        return entities.Include(x => x.Realtor);
    }
}