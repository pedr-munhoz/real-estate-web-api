using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;

namespace real_estate_web_api.Services;

public static class DatabaseManagementService
{
    public static void MigrationInitialisation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<ServerDbContext>()?.Database.Migrate();
        }
    }
}