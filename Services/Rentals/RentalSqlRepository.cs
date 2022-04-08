using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities.Rentals;

namespace real_estate_web_api.Services.Rentals;

public class RentalSqlRepository : EntitySqlRepository<Rental>
{
    public RentalSqlRepository(ServerDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Rental> LoadEntity(DbSet<Rental> dbSet)
        => dbSet
            .IncludeRealEstate()
            .IncludeRealtor()
            .IncludeTenant();

    protected override void UpdateFields(Rental dbEntity, Rental entity)
    {
        dbEntity.EndDate = entity.EndDate;
        dbEntity.MonthlyAmount = entity.MonthlyAmount;
        dbEntity.Realtor = entity.Realtor;
    }
}
