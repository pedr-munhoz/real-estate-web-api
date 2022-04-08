using Microsoft.EntityFrameworkCore;

namespace real_estate_web_api.Models.Entities.Rentals;

public static class RentalQuery
{
    public static IQueryable<Rental> IncludeRealEstate(this IQueryable<Rental> entities)
    {
        return entities.Include(x => x.RealEstate);
    }

    public static IQueryable<Rental> IncludeRealtor(this IQueryable<Rental> entities)
    {
        return entities.Include(x => x.Realtor);
    }

    public static IQueryable<Rental> IncludeTenant(this IQueryable<Rental> entities)
    {
        return entities.Include(x => x.Tenant);
    }
}
