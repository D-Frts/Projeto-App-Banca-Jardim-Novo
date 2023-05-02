using BancaJN.Api.Data.Repository;
using BancaJN.Api.Data.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddCors();

//var DbPath = AppDomain.CurrentDomain.BaseDirectory;

//builder.Services.AddDbContext<BancaDbContext>(options =>
//    options.UseSqlite(DbPath + builder.Configuration.GetConnectionString("DbName")));

builder.Services.AddDbContext<BancaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString"));
});

builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(options =>
//{
//    options.WithOrigins("https://localhost:7184/", "https://localhost:7184/")
//    .AllowAnyMethod()
//    .WithHeaders(HeaderNames.ContentType);
//});

app.MapCategoriasEndpoints();

app.MapProdutosEndpoints();


app.Run();
