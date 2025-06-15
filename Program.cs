// <copyright file="Program.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using DotNetEnv;
using MaplenouApi.Data;
using MaplenouApi.Interfaces;
using MaplenouApi.Repository;
using MaplenouApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
Env.Load(); // load environment variable in .env

var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
    ?? throw new Exception("CONNECTION_STRING is missing in .env");

// EF Core with PostgreSQL
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFileService, FileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
