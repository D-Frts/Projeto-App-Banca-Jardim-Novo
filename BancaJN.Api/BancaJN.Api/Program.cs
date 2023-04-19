
using BancaJN.Api.Data;
using BancaJN.Api.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BancaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefautConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Olá Mundo!");

app.MapGet("/cliente", () => new Cliente { Id = 0, Nome = "Cliente1", Sobrenome = "Teste1" });

app.Run();

