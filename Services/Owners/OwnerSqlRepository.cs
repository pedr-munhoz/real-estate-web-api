using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities;
using real_estate_web_api.Models.Entities.Owners;

namespace real_estate_web_api.Services.Owners;

public class OwnerSqlRepository : SqlRepository<Owner>
{
    public OwnerSqlRepository(ServerDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<ServiceResult<Owner>> Find(Func<Owner, bool> expression)
    {
        var entities = await _dbContext.Owners
            .IncludePerson()
            .WhereActive()
            .ToListAsync();

        var entity = entities
            .Where(expression)
            .FirstOrDefault();

        if (entity == null)
        {
            var error = new ServiceError("Entity not found", $"No entity could be located", 404);
            return new ServiceResult<Owner>(error);
        }

        return new ServiceResult<Owner>(entity);
    }

    public override async Task<ServiceResult<List<Owner>>> Retrieve()
    {
        var entities = await _dbContext.Owners
            .IncludePerson()
            .WhereActive()
            .ToListAsync();

        return new ServiceResult<List<Owner>>(entities);
    }

    public override async Task<ServiceResult<Owner>> Retrieve(long id)
    {
        var entity = await _dbContext.Owners
            .IncludePerson()
            .WhereActive()
            .WhereId(id)
            .FirstOrDefaultAsync();

        if (entity == null)
        {
            var error = new ServiceError($"{typeof(Owner).Name} not found", $"No {typeof(Owner).Name} could be located for id: {id}", 404);
            return new ServiceResult<Owner>(error);
        }

        return new ServiceResult<Owner>(entity);
    }

    public override async Task<ServiceResult<List<Owner>>> Search(Func<Owner, bool> filter, Func<Owner, bool>? secondaryFilter = null)
    {
        var entities = await _dbContext.Owners
            .IncludePerson()
            .WhereActive()
            .ToListAsync();

        var searchResult = secondaryFilter == null
            ? entities.Where(filter).ToList()
            : entities.Where(filter).Where(secondaryFilter).ToList();

        return new ServiceResult<List<Owner>>(searchResult);
    }

    public override async Task<ServiceResult<Owner>> Update(Owner entity)
    {
        var dbEntity = await _dbContext.Owners
            .IncludePerson()
            .WhereActive()
            .WhereId(entity.Id)
            .FirstOrDefaultAsync();

        if (dbEntity == null)
        {
            var error = new ServiceError($"{typeof(Owner).Name} not found", $"No {typeof(Owner).Name} could be located for id: {entity.Id}", 404);
            return new ServiceResult<Owner>(error);
        }

        dbEntity.Person.Address = entity.Person.Address;
        dbEntity.Person.BirthDate = entity.Person.BirthDate;
        dbEntity.Person.FirstName = entity.Person.FirstName;
        dbEntity.Person.LastName = entity.Person.LastName;
        dbEntity.Person.Mobile = entity.Person.Mobile;

        await _dbContext.SaveChangesAsync();

        return new ServiceResult<Owner>(dbEntity);
    }
}
