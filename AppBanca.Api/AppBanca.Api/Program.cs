using AppBanca.Api.Context;
using AppBanca.Api.Endpoints;
using AppBanca.Api.MappingProfiles;
using AppBanca.Api.Repository;
using AppBanca.Api.Repository.Iterfaces;
using AppBanca.Models.Domain;
using Microsoft.EntityFrameworkCore;

#region Adiciona registro dos Servi�os ao conteiner DI

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddDbContext<AppBancaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"));
});

builder.Services.AddAutoMapper(typeof(Mappings));

builder.Services.AddScoped <IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Supplier>, SupplierRepository>();

#endregion

#region Configura o pieline dos requsts HTTP.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
{
    policy.WithOrigins("https://localhost:7145", "http://localhost:5007");
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});

app.MapProductsEndpoints();
app.MapCategoriesEndpoints();
app.MapSuppliersEndpoints();

#endregion

app.UseHttpsRedirection();

app.Run();

