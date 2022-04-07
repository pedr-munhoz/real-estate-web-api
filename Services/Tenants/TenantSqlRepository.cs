using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Services.Tenants;

public class TenantSqlRepository : EntitySqlRepository<Tenant>
{
    public TenantSqlRepository(ServerDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Tenant> LoadEntity(DbSet<Tenant> dbSet)
        => dbSet.AsQueryable();

    protected override void UpdateFields(Tenant dbEntity, Tenant entity)
    {
    }
}
