using Persistence;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using MovieStore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add configuration file
builder.Configuration.AddJsonFile("appsettings.json", optional: true);

// Add services to the container.
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();




builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
}); // buras� ACtorleri �ekercen filmleri ile �ekti�im i�in bir d�ng� olu�turuyor. Buda json'a �evirirken hata verdirdi�i i�in eklendi.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000");
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowCredentials();
        });
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
}


app.UseHttpsRedirection();
app.UseCors("AllowAnyOrigin");
app.UseAuthMiddleware();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
