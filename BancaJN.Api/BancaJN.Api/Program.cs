
using BancaJN.Api.Data;
using BancaJN.Api.Entities;
using Microsoft.AspNetCore.Components.Forms;
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


#region Endpoint GET /categorias
/// <summary>
/// Retorna todas categorias cadastradas no banco de dados, se não houver retorna Status Code 204 NoContent.
/// </summary>

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

#region Endpoint GET /categoria/id 
/// <summary>
/// Retorna a categoria cadastrada no banco de dados pelo seu Id, se não houver retorna Status Code 404 NotFound.
/// </summary>

app.MapGet("/categoria/{id:int}", async (int id, BancaDbContext bancaDbContext) =>
{
    try
    {
        var categoria = await bancaDbContext.Categorias.FindAsync(id);
        return (categoria is not null) ? Results.Ok(categoria) : Results.NotFound("Categoria não encontrada!");

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

#region Endpoint POST /categoria
/// <summary>
/// Cadastra uma categoria e persiste no banco de dados.
/// </summary>

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

#region Endpoint PUT /categoria/id
/// <summary>
/// Altera parametros de uma categoria cadastradas no banco de dados pelo Id.
/// Se o Id não corresponder a categoria passada, retorna Status Code 400 BadRequest;
/// Se a categoria a ser alterada for nula, retorna Status Code 404 NotFound.
/// </summary>

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

#region Endpoint DELETE /categoria/id
/// <summary>
/// Excui categoria cadastrada no banco de dados pelo Id, se não existir retorna Status Code 404 NotFound.
/// </summary>
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
.WithName("DeletaCategoriaPeloId")
.WithTags(EndpointGroupTags.Categorias);

#endregion

#region Endpoint POST /produto
///<summary>
///Cadastra um produto e persiste no banco de dados, se for nulo retorna Status Code 400 BadRequest.
/// </summary>

app.MapPost("/produto", async (Produto produto, BancaDbContext bancaDbContext) =>
{
    try
    {
        if (produto is null)
            return Results.BadRequest();

        await bancaDbContext.AddAsync(produto);
        await bancaDbContext.SaveChangesAsync();

        return Results.Created($"/produto/{produto.Id}", produto);
    }
    catch (Exception)
    {

        throw;
    }

})
.Produces(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithTags(EndpointGroupTags.Produtos);

#endregion

#region Endpoint GET /produtos
///<summary>
///Retorna todos os produtos cadastrados no banco de dados, se não existir retorna Status Code 204 NoContent
///</summary>
app.MapGet("/produtos", async (BancaDbContext bancaDbContext) =>
{
    try
    {
        return await bancaDbContext.Produtos.ToListAsync() is IEnumerable<Produto> produtos
                                                            ? Results.Ok(produtos)
                                                            : Results.NoContent();


    }
    catch (Exception)
    {

        throw;
    }
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status204NoContent)
.WithTags(EndpointGroupTags.Produtos);


#endregion

#region Endpoint GET /produtos/id
///<summary>
///Retorna um produtos cadastrado no banco de dados pelo Id, se não existir retorna Status Code 404 NotFound
///</summary>
app.MapGet("/produto/{id:int}", async (int id, BancaDbContext bancaDbContext) =>
{
    try
    {
        return await bancaDbContext.Produtos.FindAsync(id) is Produto produto
                                                            ? Results.Ok(produto)
                                                            : Results.NotFound("Produto não encontrado!");
    }
    catch (Exception)
    {

        throw;
    }
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithTags(EndpointGroupTags.Produtos);


#endregion

#region Endpoint GET /produtos/criterio
///<summary>
///Retorn produtos cadastrado no banco de dados pelo criterio informado, se não existir retorna Status Code 404 NotFound.
///Exemplo de criterio: prdutos que contem 'A' no nome ou 'ADA' serão retornado em uma coleção de produtos
///</summary>
app.MapGet("/produto/{criterio}", async (string criterio, BancaDbContext bancaDbContext) =>
{
    try
    {
        var produtosComCriterio = await bancaDbContext.Produtos.Where(prd => prd.Nome.ToLower()
                                                                      .Contains(criterio.ToLower()))
                                                                      .ToListAsync();
        return produtosComCriterio.Count > 0 ? Results.Ok(produtosComCriterio)
                                             : Results.NotFound("Nenhum produto atende ao criterio informado!");

    }
    catch (Exception)
    {

        throw;
    }
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithTags(EndpointGroupTags.Produtos);


#endregion


#region Endpoint PUT /produto
///<summary>
///Altera propriedades nome de um produto no banco de dados pelo Verbo PUT.
/// </summary>

app.MapPut("/produto", async (int produtoId, string produtoNome, BancaDbContext bancaDbContext) =>
{
    try
    {
        var produtoAlterar = await bancaDbContext.Produtos.SingleOrDefaultAsync(p => p.Id == produtoId);

        if (produtoAlterar is null) return Results.NotFound("Produto não encontrado!");

        produtoAlterar.Nome = produtoNome;

        await bancaDbContext.SaveChangesAsync();

        return Results.Ok(produtoAlterar);
    }
    catch (Exception)
    {

        throw;
    }
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithTags(EndpointGroupTags.Produtos);

#endregion

#region Endpoint PUT /produto/id
///<summary>
///Altera toda entidade produto no banco de dados pelo Verbo PUT com novas propriendades recebidas via parametro.
/// </summary>

app.MapPut("/produto/{id:int}", async (int id, Produto produto, BancaDbContext bancaDbContext) =>
{
    try
    {
        if (produto.Id != id) return Results.BadRequest("Id's não conferem!");

        var produtoAlterar = await bancaDbContext.Produtos.SingleOrDefaultAsync(p => p.Id == id);

        if (produtoAlterar is null) return Results.NotFound("Produto não encontrado!");

        produtoAlterar.Nome = produto.Nome;
        produtoAlterar.Codigo = produto.Codigo;
        produtoAlterar.Descricao = produto.Descricao;
        produtoAlterar.Preco = produto.Preco;
        produtoAlterar.Quantidade = produtoAlterar.Quantidade;
        produtoAlterar.ImagemUrl = produto.ImagemUrl;
        produtoAlterar.CategoriaId = produto.CategoriaId;

        await bancaDbContext.SaveChangesAsync();

        return Results.Ok(produtoAlterar);
    }
    catch (Exception)
    {

        throw;
    }
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status404NotFound)
.WithTags(EndpointGroupTags.Produtos);

#endregion

#region Endpoint DELETE /produto/id
///<summary>
///Exclui um produto no banco de dados pelo Id informado, se não encontrado retorna Status Code 404 NotFound
/// </summary>

app.MapDelete("/produto/{id:int}", async (int id, BancaDbContext bancaDbContext) =>
{
    try
    {
        var produtoExcluir = await bancaDbContext.Produtos.FindAsync(id);

        if (produtoExcluir is null) return Results.NotFound("Produto não encontrado!");

        bancaDbContext.Produtos.Remove(produtoExcluir);
        await bancaDbContext.SaveChangesAsync();

        return Results.Ok(produtoExcluir);

    }
    catch (Exception)
    {

        throw;
    }
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithTags(EndpointGroupTags.Produtos);

#endregion

app.Run();


public static class EndpointGroupTags
{
    public const string Categorias = "Categorias";
    public const string Produtos = "Produtos";
    public const string Clientes = "Clientes";
    public const string Fornecedores = "Fornecedores";
}