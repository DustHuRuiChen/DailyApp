using DailyApp.API.AutoMappers;
using DailyApp.API.DataModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(m=>
    {
        string path = AppContext.BaseDirectory + "DailyApp.API.xml";
        m.IncludeXmlComments(path, true);
    });
//数据库上下文
builder.Services.AddDbContext<DailyDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
//DTO转换为数据模型注入服务
builder.Services.AddAutoMapper(typeof(AutoMapperSetting));


 
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
