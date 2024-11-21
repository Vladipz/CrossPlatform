using App.Controllers;
using App.Endpoints;
using App.Models;
using App.Services;
using Auth0.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var databaseProvider = builder.Configuration["DatabaseProvider"];
builder.Services.AddDbContext<SpecialistBookshopDbContext>(options =>
{
    _ = databaseProvider switch
    {
        "Sqlite" => options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"), o => o.MigrationsAssembly("App.Sqlite")),
        "SqlServer" => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), o => o.MigrationsAssembly("App.SqlServer")),
        "Postgres" => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"), o => o.MigrationsAssembly("App.Postgres")),
        "InMemory" => options.UseInMemoryDatabase("InMemory"),
        _ => throw new InvalidOperationException("Invalid database provider"),
    };
});


builder.Services.AddControllersWithViews();
builder.Services.AddTransient<AuthService>();
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.ClientId = builder.Configuration["Auth0:ClientId"]!;
});

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.AddHttpClient<BooksController>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<SpecialistBookshopDbContext>();
await Seeder.SeedAsync(dbContext);


if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapOrdersEndpoints();
app.MapBooksEndpoints();

app.Run();
