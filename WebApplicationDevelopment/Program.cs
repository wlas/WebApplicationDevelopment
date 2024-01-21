using Microsoft.EntityFrameworkCore;
using WebApplicationDevelopment;
using WebApplicationDevelopment.Interfaces;
using WebApplicationDevelopment.Models.DTO;
using WebApplicationDevelopment.Services;

var builder = WebApplication.CreateBuilder(args);

// Подключаем конфиг из appsettings.json
builder.Configuration.Bind("Project", new Config());

// Add services to the container.
builder.Services.AddDbContext<MyContext>(x => x.UseNpgsql(Config.ConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProFile));

builder.Services.AddTransient<IEntityService<CategoryDto>, CategoryService>();
builder.Services.AddTransient<IEntityService<ProductDto>, ProductService>();
builder.Services.AddTransient<IEntityService<StoreDto>, StoreService>();


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
