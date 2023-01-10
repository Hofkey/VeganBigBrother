var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup infrastructure.
#region Infrastructure setup.
VeganBigBrother.Infrastructure.Setup.AddContext(builder.Services,
    builder.Configuration.GetValue<string>("Database:Source"),
    builder.Configuration.GetValue<string>("Database:Name"),
    builder.Configuration.GetValue<string>("Database:User"),
    builder.Configuration.GetValue<string>("Database:Password"));

VeganBigBrother.Infrastructure.Setup.SetupRepositories(builder.Services);
#endregion

// Build the app.
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
