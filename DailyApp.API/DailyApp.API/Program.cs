using DailyApp.API.AutoMappers;
using DailyApp.API.DataModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(m =>
{
    string path = AppContext.BaseDirectory + "DailyApp.API.xml";
    m.IncludeXmlComments(path, true);
});

var connection = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("ConnStr"));
var passwordFile = builder.Configuration["Database:PasswordFile"];
if (!string.IsNullOrEmpty(passwordFile))
{
    connection.Password = File.ReadAllText(passwordFile).TrimEnd('\r', '\n');
}
builder.Services.AddDbContext<DailyDbContext>(m => m.UseSqlServer(connection.ConnectionString));

builder.Services.AddAutoMapper(typeof(AutoMapperSettings));
var app = builder.Build();

if (app.Configuration.GetValue<bool>("Database:ApplyMigrations"))
{
    await using var scope = app.Services.CreateAsyncScope();
    var db = scope.ServiceProvider.GetRequiredService<DailyDbContext>();
    await db.Database.MigrateAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/health/ready", async (DailyDbContext db, CancellationToken token) =>
    await db.Database.CanConnectAsync(token) ? Results.Ok("DailyApp ready") : Results.StatusCode(503));

app.Run();
