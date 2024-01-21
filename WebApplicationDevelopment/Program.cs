using WebApplicationDevelopment.Interfaces;
using WebApplicationDevelopment.Models.DTO;
using WebApplicationDevelopment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProFile));

builder.Services.AddSingleton<IEntityService<CategoryDto>, CategoryService>();
builder.Services.AddSingleton<IEntityService<ProductDto>, ProductService>();
builder.Services.AddSingleton<IEntityService<StoreDto>, StoreService>();

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
