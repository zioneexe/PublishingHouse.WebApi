using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Service;
using PublishingHouse.DAL;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Data.Seed;
using PublishingHouse.DAL.Repository;
using PublishingHouse.WebApi.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Logging.AddConsole().SetMinimumLevel(LogLevel.Debug);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddModels();
builder.AddDbContextServices();
builder.AddRepositories();
builder.AddServices();
builder.AddMappers();
builder.AddAuthServices();
builder.AddIdentityServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var contextDb = services.GetRequiredService<PublishingHouseDbContext>();
        contextDb.Database.Migrate();

        var contextAuth = services.GetRequiredService<AuthDbContext>();
        contextAuth.Database.Migrate();

        Console.WriteLine("Migration successful!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Migration failed: {ex.Message}");
    }
}

using (var scope = app.Services.CreateScope())
{
    await DatabaseSeeder.SeedDataAsync(scope.ServiceProvider);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

app.Run();