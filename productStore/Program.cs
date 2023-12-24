using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productStore.BLL.Models;
using productStore.BLL.Repositories;
using productStore.DAL;
using productStore.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IProductInStoreRepository, ProductInStoreRepository>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreDbContext>(option => option.UseNpgsql(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

dbContext.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//BLL, DAL - библиотеки классов, BLL- основная логика приложения, логика работы с данными и принцип принятия и выдачи данный
// Dal - вся рвбота с данными, 
// какие-то контракты между блл и клиентом, (интерфейс), папочка сервисы, кот осущ логику
// dto - data transfer object - BLL
// моде