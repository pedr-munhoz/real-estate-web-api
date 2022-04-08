using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities;
using real_estate_web_api.Models.Entities.RealEstates;

namespace real_estate_web_api.Services.RealEstates;

public class RealEstateSqlRepository : EntitySqlRepository<RealEstate>
{
    public RealEstateSqlRepository(ServerDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<RealEstate> LoadEntity(DbSet<RealEstate> dbSet)
        => dbSet
            .IncludeOwner()
            .IncludeRealtor();

    protected override void UpdateFields(RealEstate dbEntity, RealEstate entity)
    {
        dbEntity.Type = entity.Type;
        dbEntity.GrossBuildingArea = entity.GrossBuildingArea;
        dbEntity.Bedrooms = entity.Bedrooms;
        dbEntity.ParkingSpaces = entity.ParkingSpaces;
        dbEntity.SaleAvailable = entity.SaleAvailable;
        dbEntity.SaleAmount = entity.SaleAmount;
        dbEntity.RentAvailable = entity.RentAvailable;
        dbEntity.RentAmount = entity.RentAmount;
        dbEntity.Owner = entity.Owner;
        dbEntity.Realtor = entity.Realtor;
    }
}
