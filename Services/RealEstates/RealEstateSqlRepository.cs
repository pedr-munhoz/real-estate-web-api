using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities;
using real_estate_web_api.Models.Entities.RealEstates;

namespace real_estate_web_api.Services.RealEstates;

public class RealEstateSqlRepository : SqlRepository<RealEstate>
{
    public RealEstateSqlRepository(ServerDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<ServiceResult<RealEstate>> Find(Func<RealEstate, bool> expression)
    {
        var entities = await _dbContext.RealEstates
            .IncludeOwner()
            .IncludeRealtor()
            .WhereActive()
            .ToListAsync();

        var entity = entities
            .Where(expression)
            .FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError("Entity not found", $"No entity could be located", 404);
            return new ServiceResult<RealEstate>(error);
        }

        return new ServiceResult<RealEstate>(entity);
    }

    public override async Task<ServiceResult<List<RealEstate>>> Retrieve()
    {
        var entities = await _dbContext.RealEstates
            .IncludeOwner()
            .IncludeRealtor()
            .WhereActive()
            .ToListAsync();

        return new ServiceResult<List<RealEstate>>(entities);
    }

    public override async Task<ServiceResult<RealEstate>> Retrieve(long id)
    {
        var entity = await _dbContext.RealEstates
            .IncludeOwner()
            .IncludeRealtor()
            .WhereActive()
            .WhereId(id)
            .FirstOrDefaultAsync();

        if (entity == null)
        {
            var error = new ServiceError($"{typeof(RealEstate).Name} not found", $"No {typeof(RealEstate).Name} could be located for id: {id}", 404);
            return new ServiceResult<RealEstate>(error);
        }

        return new ServiceResult<RealEstate>(entity);
    }

    public override async Task<ServiceResult<List<RealEstate>>> Search(Func<RealEstate, bool> filter, Func<RealEstate, bool>? secondaryFilter = null)
    {
        var entities = await _dbContext.RealEstates
            .IncludeOwner()
            .IncludeRealtor()
            .WhereActive()
            .ToListAsync();

        var searchResult = secondaryFilter == null
            ? entities.Where(filter).ToList()
            : entities.Where(filter).Where(secondaryFilter).ToList();

        return new ServiceResult<List<RealEstate>>(searchResult);
    }

    public override async Task<ServiceResult<RealEstate>> Update(RealEstate entity)
    {
        var dbEntity = await _dbContext.RealEstates
            .IncludeOwner()
            .IncludeRealtor()
            .WhereActive()
            .WhereId(entity.Id)
            .FirstOrDefaultAsync();

        if (dbEntity == null)
        {
            var error = new ServiceError($"{typeof(RealEstate).Name} not found", $"No {typeof(RealEstate).Name} could be located for id: {entity.Id}", 404);
            return new ServiceResult<RealEstate>(error);
        }

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

        await _dbContext.SaveChangesAsync();

        return new ServiceResult<RealEstate>(dbEntity);
    }
}
