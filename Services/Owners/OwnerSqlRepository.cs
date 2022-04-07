using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities.Owners;

namespace real_estate_web_api.Services.Owners;

public class OwnerSqlRepository : EntitySqlRepository<Owner>
{
    public OwnerSqlRepository(ServerDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Owner> LoadEntity(DbSet<Owner> dbSet)
        => dbSet.IncludePerson();

    protected override void UpdateFields(Owner dbEntity, Owner entity)
    {
        dbEntity.Person.Address = entity.Person.Address;
        dbEntity.Person.BirthDate = entity.Person.BirthDate;
        dbEntity.Person.FirstName = entity.Person.FirstName;
        dbEntity.Person.LastName = entity.Person.LastName;
        dbEntity.Person.Mobile = entity.Person.Mobile;
    }
}
