using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()); //serialize all enums
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddTransient<IRepository<Person>, ListRepository<Person>>();
builder.Services.AddTransient<IRepository<IRealEstate>, ListRepository<IRealEstate>>();
builder.Services.AddTransient<IRepository<Rental>, ListRepository<Rental>>();

builder.Services.AddTransient<IManager<IOwner>, OwnerManager>();
builder.Services.AddTransient<IManager<IRealtor>, RealtorManager>();
builder.Services.AddTransient<IManager<ITenant>, TenantManager>();
builder.Services.AddTransient<IManager<IRealEstate>, StandardManager<IRealEstate>>();
builder.Services.AddTransient<IManager<Rental>, StandardManager<Rental>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
