using ApiGW;
using ApiGW.Query;
using Microsoft.EntityFrameworkCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using WebApplicationDevelopment;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration config = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(config);
builder.Services.AddSwaggerForOcelot(config);


builder.Services
			.AddSingleton<IStorageService, StorageService>()
			.AddGraphQLServer()
			.AddQueryType<GetProducts>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerForOcelotUI(opt =>
{
	opt.PathToSwaggerGenerator = "/swagger/docs";
}).UseOcelot().Wait();


app.UseHttpsRedirection();
app.MapGraphQL();
app.Run();

