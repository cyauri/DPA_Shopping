using DPA.Shopping.DOMAIN.Core.Interfaces;
using DPA.Shopping.DOMAIN.Infrastructure.Data;
using DPA.Shopping.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _conf = builder.Configuration;
var _cnx = _conf.GetConnectionString("DevConnection");
builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(_cnx);
});

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
