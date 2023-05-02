using AutoMapper;
using BancaJN.Api.Data;
using BancaJN.Api.Data.Repository.Contracts;
using BancaJN.Api.Entities;
using BancaJN.Api.Mapping;
using BancaJN.Model.DataTransferObjects;
using static Microsoft.AspNetCore.Http.Results;

namespace BancaJN.Api.Endpoints;

public static class ProdutosEndpoints
{

    public static void MapProdutosEndpoints(this WebApplication app)
    {

        #region Endpoint GET /produtos
        ///<summary>
        ///Retorna todos os produtos cadastrados no banco de dados, se não existir retorna Status Code 204 NoContent
        ///</summary>

        app.MapGet("/produtos", async (IProdutoRepositorio repositorio, IMapper mapper) =>
        {
            try
            {
                var produtos = await repositorio.ObtemItens();

                var produtosDto = mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

                if (produtosDto.Count() < 0) return NoContent();

                return Ok(produtosDto);


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

        app.MapGet("/produto/{id:int}", async (int id, IProdutoRepositorio repositorio, IMapper mapper) =>
        {
            try
            {
                var produto = await repositorio.ObtemItemPorId(id);

                if (produto is null) return NotFound();

                var produtoDto = mapper.Map<ProdutoDTO>(produto);

                return Ok(produtoDto);
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
   
        app.MapGet("/produtos/{criterio}", async (string criterio, 
                                                  IProdutoRepositorio repositorio,
                                                  IMapper mapper) =>
        {
            try
            {
                var produtos = await repositorio.ObtemItens();
                var produtosComCriterio = produtos.Where(p => p.Nome.ToLower()
                                                        .Contains(criterio.ToLower()))
                                                        .ToList();
                if (produtosComCriterio.Count() < 0)
                    return NotFound("Nenhum produto atende ao criterio informado!");

                var produtosComCriterioDto = mapper.Map<IEnumerable<ProdutoDTO>>(produtosComCriterio);

                return Ok(produtosComCriterioDto);

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

        //app.MapGet("/produtosporpagina", async (int numeroPagina, int tamanhoPagina, BancaDbContext bancaDbContext) =>
        //{
        //    try
        //    {
        //        return await bancaDbContext.Produtos
        //                                   .Skip((numeroPagina - 1) * tamanhoPagina)
        //                                   .Take(tamanhoPagina)
        //                                   .ToListAsync();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //})
        //.Produces(StatusCodes.Status200OK)
        //.Produces(StatusCodes.Status404NotFound)
        //.WithTags(EndpointGroupTags.Produtos);

        app.MapGet("/produtosporpagina", async (int numeroPagina, 
                                                int tamanhoPagina, 
                                                IProdutoRepositorio repositorio,
                                                IMapper mapper) =>
        {
            try
            {
                var produtos = await repositorio.ObtemItens();

                var produtosPaginados = produtos.Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina);

                if (produtos is null) return NoContent();

                var produtosDto = mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

                return Ok(produtosDto);

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

        #region Endpoint POST /produto
        ///<summary>
        ///Cadastra um produto e persiste no banco de dados, se for nulo retorna Status Code 400 BadRequest.
        /// </summary>

        app.MapPost("/produto", async (ProdutoDTO produtoDto, IProdutoRepositorio repositorio, IMapper mapper) =>
        {
            try
            {    
                var produto = await repositorio.AdicionaItem(mapper.Map<Produto>(produtoDto));


                return produto is not null ? Created($"/produto/{produto.Id}", produto)
                                           : BadRequest("Item já exite");
                                                                 

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

        #region Endpoint PUT /produto
        ///<summary>
        ///Altera propriedades nome de um produto no banco de dados pelo Verbo PUT.
        /// </summary>

        //app.MapPut("/produto", async (int produtoId, string produtoNome, BancaDbContext bancaDbContext) =>
        //{
        //    try
        //    {
        //        var produtoAlterar = await bancaDbContext.Produtos.SingleOrDefaultAsync(p => p.Id == produtoId);

        //        if (produtoAlterar is null) return Results.NotFound("Produto não encontrado!");

        //        produtoAlterar.Nome = produtoNome;

        //        await bancaDbContext.SaveChangesAsync();

        //        return Results.Ok(produtoAlterar);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //})
        //.Produces(StatusCodes.Status200OK)
        //.Produces(StatusCodes.Status404NotFound)
        //.WithTags(EndpointGroupTags.Produtos);

        #endregion

        #region Endpoint PUT /produto/id

        ///<summary>
        ///Altera toda entidade produto no banco de dados pelo Verbo PUT com novas propriedades recebidas via parametro.
        /// </summary>

        app.MapPut("/produto/{itemId:int}", async (int itemId,
                                                   ProdutoDTO produtoDto, 
                                                   IProdutoRepositorio repositorio, 
                                                   IMapper mapper) =>
        {
            try
            {
                if (itemId != produtoDto.Id) return BadRequest("Id's não conferem");

                var produtoAtualizado = await repositorio.AtualizaItem(mapper.Map<Produto>(produtoDto));

                return produtoAtualizado is null ? NotFound("Produto não encontrado!")
                                                 : Ok(produtoAtualizado);
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

        app.MapDelete("/produto/{itemId:int}", async (int itemId, IProdutoRepositorio repositorio) =>
        {
            try
            {
                var resultado = await repositorio.ExcluiItemPorId(itemId);

                if (resultado is null)
                    return NotFound("Item não encontrado!");

                return Ok(resultado);
            }
            catch (Exception)
            {

                throw;
            }

        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithTags(EndpointGroupTags.Produtos);

        #endregion

    }
}
