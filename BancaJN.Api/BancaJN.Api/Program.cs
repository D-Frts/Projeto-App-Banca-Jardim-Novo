
using BancaJN.Api.Data;
using BancaJN.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BancaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Configura Endpoint GET /categorias
#region

app.MapGet("/categorias", async (BancaDbContext bancaDbContext) =>
{
    try
    {
        var categorias = await bancaDbContext.Categorias.ToListAsync();

        if (categorias == null)
        {
            return Results.NoContent();
        }

        return Results.Ok(categorias);
    }
    catch (Exception)
    {
        //Log
        throw;
    }
})
.WithTags(EndpointGroupTags.Categorias)
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status204NoContent);

#endregion

//Configura Endpoint GET /categria/id
#region

app.MapGet("/categoria/{id:int}", async (int id, BancaDbContext bancaDbContext) =>
{
    try
    {
        var categoria = await bancaDbContext.Categorias.FindAsync(id);
        return (categoria is not null) ? Results.Ok(categoria) : Results.NotFound();

    }
    catch (Exception)
    {
        //Log 
        throw;
    }
})
.WithTags(EndpointGroupTags.Categorias)
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

#endregion

//Configura Endpoint POST /categoria
#region

//[Opcional]: [FromBody] especifica que o objeto JSON será passado como parametro
//[Opcional]: [FromServices] define que o parametro será injetado do conteiner DI
app.MapPost("/categoria", async ([FromBody] Categoria categoria, [FromServices] BancaDbContext bancaDbContext) =>
{
    try
    {
        await bancaDbContext.AddAsync(categoria);

        await bancaDbContext.SaveChangesAsync();

        //Reults é usado para produzir response HTTPs comuns como: Ok, NotFound, BadRequest, Created ...
        var result = Results.Created($"/categoria/{categoria.Id}", categoria);

        return result;

    }
    catch (Exception)
    {

        throw;
    }
})
.Accepts<Categoria>("application/json") //[Opcional]: especifica o body do request e o Content Type usado
.Produces(StatusCodes.Status201Created) //[Opcional]: define o tipo de retorno e o status esperado
.WithName("CriarNovaCategoria") //[Opcional]: identifica o endpoint de forma unica
.WithTags(EndpointGroupTags.Categorias); //[Opcional]: agrupa os endpoints

#endregion

//Configura Endpoint PUT /categoria/id
#region

app.MapPut("/categoria/{id:int}", async (int id, Categoria categoria, BancaDbContext bancaDbContext) =>
{
    try
    {
        if (categoria.Id != id)
            return Results.BadRequest();

        var categoriaAlterada = await bancaDbContext.Categorias.FindAsync(id);

        if (categoriaAlterada == null)
            return Results.NotFound();

        categoriaAlterada.Nome = categoria.Nome;

        await bancaDbContext.SaveChangesAsync();

        return Results.Ok(categoriaAlterada);
    }
    catch (Exception)
    {

        throw;
    }
})
.WithTags(EndpointGroupTags.Categorias)
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status404NotFound);

#endregion

//Configura Endpoint DELETE /categoria/id
#region

app.MapDelete("/categoria/{id:int}", async (int id, BancaDbContext bancaDbContext) =>
{
    try
    {
        var categoriaExcluir = await bancaDbContext.Categorias.FindAsync(id);

        if (categoriaExcluir is null)
            return Results.NotFound();

        bancaDbContext.Categorias.Remove(categoriaExcluir);
        await bancaDbContext.SaveChangesAsync();

        return Results.NoContent();

    }
    catch (Exception)
    {

        throw;
    }

})
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithTags(EndpointGroupTags.Categorias);

#endregion



app.Run();

public static class EndpointGroupTags
{
    public const string Categorias = "Categorias";
    public const string Produtos = "Produtos";
    public const string Clientes = "Clientes";
    public const string Fornecedores = "Fornecedores";
}