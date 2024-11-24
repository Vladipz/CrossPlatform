using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Додати автентифікацію
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
        options.Audience = builder.Configuration["Auth0:Audience"];
    });

builder.Services.AddAuthorization();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Labs API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()    // дозволяє запити з будь-якого домену
              .AllowAnyHeader()    // дозволяє будь-які заголовки
              .AllowAnyMethod();   // дозволяє будь-які HTTP методи (GET, POST, PUT тощо)
    });
});

var app = builder.Build();

// Configure AddCors
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Labs API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
