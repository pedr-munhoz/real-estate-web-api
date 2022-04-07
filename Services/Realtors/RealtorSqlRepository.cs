using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities.Realtors;

namespace real_estate_web_api.Services.Realtors;

public class RealtorSqlRepository : EntitySqlRepository<Realtor>
{
    public RealtorSqlRepository(ServerDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Realtor> LoadEntity(DbSet<Realtor> dbSet)
        => dbSet.AsQueryable();

    protected override void UpdateFields(Realtor dbEntity, Realtor entity)
    {
    }
}
