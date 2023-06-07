using ApiPizza.DbContexts;
using ApiPizza.Exceptions;
using ApiPizza.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuracion de la conexion a la BD
var configuration = builder.Configuration.GetConnectionString("DbProduct");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration));

builder.Services.AddScoped<IProductRepository, ProductSQLRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalExceptionHandler));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
