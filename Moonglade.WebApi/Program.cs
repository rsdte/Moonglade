using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Moonglade.Application;
using Moonglade.EntityFrameworkCore;
using Moonglade.WebApi.Filters;

var ALLSPECIFICORIGINS = "ALLSPECIFICORIGINS";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddDbContext<MoongladeDbContext>(opts =>
{
    var sqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServer");
    opts.UseSqlServer(sqlServerConnectionString);
});

builder.Services.AddCors(opts =>
{
    opts.AddPolicy(
        name: ALLSPECIFICORIGINS,
        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
       );
});


var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(config =>
        {
            config.SaveToken = true;
            config.RequireHttpsMetadata = true;
            config.TokenValidationParameters = jwtConfig.TokenValidationParameters;
        });

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers(opts =>
{
    opts.Filters.Add<GlobalExceptionFilter>();
});

var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
app.UseCors(ALLSPECIFICORIGINS);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
