using BEERCRUD.DTOs;
using BEERCRUD.Models;
using BEERCRUD.Repository;
using BEERCRUD.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});
// Servicios
builder.Services.AddKeyedScoped<ICommonService<BeerDto, BeertInsertDto, BeerUpdateDto>, BeerService>("beerService");
// Repositorio
builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();
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
