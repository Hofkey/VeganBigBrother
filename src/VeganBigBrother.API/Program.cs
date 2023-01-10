using VeganBigBrother.Core.Services.LocationServices;
using VeganBigBrother.Core.Services.SensorServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Setup infrastructure.
#region Infrastructure setup.
VeganBigBrother.Infrastructure.Setup.AddContext(builder.Services,
    builder.Configuration.GetValue<string>("Database:Source"),
    builder.Configuration.GetValue<string>("Database:Name"),
    builder.Configuration.GetValue<string>("Database:User"),
    builder.Configuration.GetValue<string>("Database:Password"));

VeganBigBrother.Infrastructure.Setup.SetupRepositories(builder.Services);
#endregion

builder.Services.AddScoped<ISensorService, SensorService>();
builder.Services.AddScoped<ISensorPartService, SensorPartService>();
builder.Services.AddScoped<ILocationService, LocationService>();

// Build the app.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
