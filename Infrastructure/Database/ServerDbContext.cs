using Microsoft.EntityFrameworkCore;

namespace real_estate_web_api.Infrastructure.Database
{
    public class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions options) : base(options) { }
    }
}