var ALLSPECIFICORIGINS = "ALLSPECIFICORIGINS";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opts =>
{
    opts.AddPolicy(
        name: ALLSPECIFICORIGINS,
        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
       );
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(ALLSPECIFICORIGINS);
app.UseAuthorization();

app.MapControllers();

app.Run();
