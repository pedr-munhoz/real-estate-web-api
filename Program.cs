using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Infrastructure.Database;
using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Models.Entities.Tenants;
using real_estate_web_api.Services;
using real_estate_web_api.Services.Owners;
using real_estate_web_api.Services.RealEstates;
using real_estate_web_api.Services.Realtors;
using real_estate_web_api.Services.Rentals;
using real_estate_web_api.Services.Tenants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration["ServerDbConnectionString"];

builder.Services.AddDbContext<ServerDbContext>(options =>
    options.UseNpgsql(connectionString)
);

builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()); //serialize all enums
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddTransient<IRepository<Owner>, OwnerSqlRepository>();
builder.Services.AddTransient<IRepository<Realtor>, RealtorSqlRepository>();
builder.Services.AddTransient<IRepository<Tenant>, TenantSqlRepository>();
builder.Services.AddTransient<IRepository<RealEstate>, RealEstateSqlRepository>();
builder.Services.AddTransient<IRepository<Rental>, RentalSqlRepository>();

builder.Services.AddTransient<IOwnerManager, OwnerManager>();
builder.Services.AddTransient<IRealtorManager, RealtorManager>();
builder.Services.AddTransient<ITenantManager, TenantManager>();
builder.Services.AddTransient<IRealEstateManager, RealEstateManager>();
builder.Services.AddTransient<IRentalManager, RentalManager>();

var app = builder.Build();

DatabaseManagementService.MigrationInitialisation(app);

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
