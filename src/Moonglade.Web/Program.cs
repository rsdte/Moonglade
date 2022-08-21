using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Moonglade.Application;
using Moonglade.EntityFrameworkCore;
using Moonglade.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddDbContext<MoongladeDbContext>(opts =>
{
    var sqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServer");
    opts.UseSqlServer(sqlServerConnectionString);
});
builder.Services.AddRepositories();
builder.Services.AddAllService();

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
builder.Services.AddMvc(opts =>
{
    opts.Filters.Add<GlobalExceptionFilter>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();
