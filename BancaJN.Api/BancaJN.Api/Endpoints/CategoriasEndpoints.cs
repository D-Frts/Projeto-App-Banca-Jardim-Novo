namespace BancaJN.Api.Endpoints;

public static class CategoriasEndpoints
{
    public static void MapCategoriasEndpoints(this WebApplication app)
    {
        //#region Endpoint GET /categorias
        /// <summary>
        /// Retorna todas categorias cadastradas no banco de dados, se não houver retorna Status Code 204 NoContent.
        /// </summary>

        //app.MapGet("/categorias", async (BancaDbContext bancaDbContext) =>
        //{
        //    try
        //    {
        //        var categorias = await bancaDbContext.Categorias.ToListAsync();

        //        if (categorias == null)
        //        {
        //            return Results.NoContent();
        //        }

        //        return Results.Ok(categorias);
        //    }
        //    catch (Exception)
        //    {
        //        Log
        //        throw;
        //    }
        //})
        //.WithTags(EndpointGroupTags.Categorias)
        //.Produces(StatusCodes.Status200OK)
        //.Produces(StatusCodes.Status204NoContent);

        //#endregion

        //#region Endpoint GET /categoria/id 
        /// <summary>
        /// Retorna a categoria cadastrada no banco de dados pelo seu Id, se não houver retorna Status Code 404 NotFound.
        /// </summary>

        //app.MapGet("/categoria/{id:int}", async (int id, BancaDbContext bancaDbContext) =>
        //{
        //    try
        //    {
        //        var categoria = await bancaDbContext.Categorias.FindAsync(id);
        //        return (categoria is not null) ? Results.Ok(categoria) : Results.NotFound("Categoria não encontrada!");

        //    }
        //    catch (Exception)
        //    {
        //        Log 
        //        throw;
        //    }
        //})
        //.WithTags(EndpointGroupTags.Categorias)
        //.Produces(StatusCodes.Status200OK)
        //.Produces(StatusCodes.Status404NotFound);

        //#endregion

        //#region Endpoint POST /categoria
        /// <summary>
        /// Cadastra uma categoria e persiste no banco de dados.
        /// </summary>

        //[Opcional]: [FromBody] especifica que o objeto JSON será passado como parametro
        //[Opcional]: [FromServices] define que o parametro será injetado do conteiner DI
        //app.MapPost("/categoria", async ([FromBody] Categoria categoria, [FromServices] BancaDbContext bancaDbContext) =>
        //{
        //    try
        //    {
        //        await bancaDbContext.AddAsync(categoria);

        //        await bancaDbContext.SaveChangesAsync();

        //        Reults é usado para produzir response HTTPs comuns como: Ok, NotFound, BadRequest, Created ...
        //        var result = Results.Created($"/categoria/{categoria.Id}", categoria);

        //        return result;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //})
        //.Accepts<Categoria>("application/json") //[Opcional]: especifica o body do request e o Content Type usado
        //.Produces(StatusCodes.Status201Created) //[Opcional]: define o tipo de retorno e o status esperado
        //.WithName("CriarNovaCategoria") //[Opcional]: identifica o endpoint de forma unica
        //.WithTags(EndpointGroupTags.Categorias); //[Opcional]: agrupa os endpoints

        //#endregion

        //#region Endpoint PUT /categoria/id
        /// <summary>
        /// Altera parametros de uma categoria cadastradas no banco de dados pelo Id.
        /// Se o Id não corresponder a categoria passada, retorna Status Code 400 BadRequest;
        /// Se a categoria a ser alterada for nula, retorna Status Code 404 NotFound.
        /// </summary>

        //app.MapPut("/categoria/{id:int}", async (int id, Categoria categoria, BancaDbContext bancaDbContext) =>
        //{
        //    try
        //    {
        //        if (categoria.Id != id)
        //            return Results.BadRequest();

        //        var categoriaAlterada = await bancaDbContext.Categorias.FindAsync(id);

        //        if (categoriaAlterada == null)
        //            return Results.NotFound();

        //        categoriaAlterada.Nome = categoria.Nome;

        //        await bancaDbContext.SaveChangesAsync();

        //        return Results.Ok(categoriaAlterada);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //})
        //.WithTags(EndpointGroupTags.Categorias)
        //.Produces(StatusCodes.Status200OK)
        //.Produces(StatusCodes.Status400BadRequest)
        //.Produces(StatusCodes.Status404NotFound);

        //#endregion

        //#region Endpoint DELETE /categoria/id
        /// <summary>
        /// Excui categoria cadastrada no banco de dados pelo Id, se não existir retorna Status Code 404 NotFound.
        /// </summary>
        //app.MapDelete("/categoria/{id:int}", async (int id, BancaDbContext bancaDbContext) =>
        //{
        //    try
        //    {
        //        var categoriaExcluir = await bancaDbContext.Categorias.FindAsync(id);

        //        if (categoriaExcluir is null)
        //            return Results.NotFound();

        //        bancaDbContext.Categorias.Remove(categoriaExcluir);
        //        await bancaDbContext.SaveChangesAsync();

        //        return Results.NoContent();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //})
        //.Produces(StatusCodes.Status204NoContent)
        //.Produces(StatusCodes.Status404NotFound)
        //.WithName("DeletaCategoriaPeloId")
        //.WithTags(EndpointGroupTags.Categorias);

        //#endregion

    }
}
