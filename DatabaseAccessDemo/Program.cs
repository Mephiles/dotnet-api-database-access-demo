using DatabaseAccessDemo.Models;
using DemoAPI.Classes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DemoAPI");
if (connectionString == null)
{
	throw new Exception("Connection string has not been set.");
}
SwaggerSqlEnumSchemaAttribute.ConnectionString = connectionString;

// Add services to the container.
builder.Services.AddDbContext<ApiDbContext>(optionsBuilder =>
	{
		optionsBuilder.UseSqlServer(connectionString);
	}
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(configuration =>
{
	configuration.EnableAnnotations();
});

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
