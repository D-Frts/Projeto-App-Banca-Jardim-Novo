namespace BancaJN.Api.Endpoints;

public static class ProdutosEndpoints
{
    public static void MapProdutosEndpoints(this WebApplication app)
    {
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

        #region Endpoint GET /produtosporpagina
        ///<summary>
        ///Retorna produtos cadastrado no banco de dados por paginação, se não existir retorna Status Code 404 NotFound.
        /// </summary>

        app.MapGet("/produtosporpagina", async (int numeroPagina, int tamanhoPagina, BancaDbContext bancaDbContext) =>
        {
            try
            {
                return await bancaDbContext.Produtos
                                           .Skip((numeroPagina - 1) * tamanhoPagina)
                                           .Take(tamanhoPagina)
                                           .ToListAsync();
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

    }
}
