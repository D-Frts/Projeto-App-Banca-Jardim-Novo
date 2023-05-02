using AppBanca.Api.Repository.Iterfaces;
using AppBanca.Models.Domain;
using AppBanca.Models.Dtos.Inputs;
using AppBanca.Models.Dtos.Outputs;
using AutoMapper;
using static Microsoft.AspNetCore.Http.Results;

namespace AppBanca.Api.Endpoints;

public static class AppBancaEndpoints
{
    public static void MapProductsEndpoints(this WebApplication app)
    {
        #region Endpoint POST /produto
        ///<summary>
        ///Cadastra um produto e persiste no banco de dados, se for nulo retorna Status Code 400 BadRequest.
        /// </summary>

        app.MapPost("/produto", async (ProductInputDto productDto, IRepository<Product> repository, IMapper mapper) =>
        {
            try
            {

                var product = mapper.Map<Product>(productDto);

                var result = await repository.Create(product);

                if (result is null) return BadRequest();

                await repository.SaveChanges();

                return Created($"/produto/{result.Id}", result);
            }
            catch (Exception)
            {

                throw;
            }

        })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithTags("Products");

        #endregion

        #region Endpoint GET /produtos
        ///<summary>
        ///Retorna todos os produtos cadastrados no banco de dados, se não existir retorna Status Code 204 NoContent
        ///</summary>

        app.MapGet("/produtos", async (IRepository<Product> repository, IMapper mapper) =>
        {
            try
            {
                var products = await repository.GetAll();

                //var productsDto = mapper.Map<IEnumerable<ProductOutpuDto>>(products);
                var productsDto = new List<ProductOutpuDto>();

                foreach (var item in products)
                {
                    productsDto.Add(mapper.Map<ProductOutpuDto>(item));
                }

                if (productsDto.Count() <= 0) return NoContent();

                return Ok(productsDto);

            }
            catch (Exception)
            {

                throw;
            }
        })
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithTags("Products");



        #endregion

        #region Endpoint DELETE /produto/id

        ///<summary>
        ///Remove um produto pelo Id da base de dados
        /// </summary>

        app.MapDelete("/produto/{id:int}", async (int id, IRepository<Product> repository) =>
        {
            var result = await repository.GetById(id);

            if (result is null) return BadRequest();

            await repository.Delete(result.Id);
            await repository.SaveChanges();

            return Ok(result);

        })
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .WithTags("Products");

        #endregion

    }
    public static void MapCategoriesEndpoints(this WebApplication app)
    {
        #region Endpoint POST /categoria

        ///<summary>
        ///Cadastra uma categoria e persiste no banco de dados, se for nulo retorna Status Code 400 BadRequest.
        /// </summary>

        app.MapPost("/categoria", async (CategoryInputDto categoryDto, IRepository<Category> repository, IMapper mapper) =>
        {
            var category = mapper.Map<Category>(categoryDto);

            var result = await repository.Create(category);

            if (result is null) return BadRequest();

            await repository.SaveChanges();

            return Created($"/categoria/{result.Id}", result);
        })
       .Produces(StatusCodes.Status201Created)
       .Produces(StatusCodes.Status400BadRequest)
       .WithTags("Categories");

        #endregion

        #region Endpoint GET /categorias        

        ///<summary>
        ///Retorna todos as categorias cadastradas no banco de dados, se não existir retorna Status Code 204 NoContent
        ///</summary>
        ///
        app.MapGet("/categorias", async (IRepository<Category> repository, IMapper mapper) =>
        {
            var categories = await repository.GetAll();

            var categoriesDto = mapper.Map<IEnumerable<CategoryOutputDto>>(categories);

            if (categories.Count() <= 0) return NoContent();

            return Ok(categoriesDto);

        })
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithTags("Categories");

        #endregion

        #region Endpoint DELETE /categoria/id

        ///<summary>
        ///Remove uma categoria pela Id da base de dados
        /// </summary>

        app.MapDelete("/categoria/{id:int}", async (int id, IRepository<Category> repository) =>
        {
            var result = await repository.GetById(id);

            if (result is null) return BadRequest();

            await repository.Delete(result.Id);
            await repository.SaveChanges();

            return Ok(result);

        })
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .WithTags("Categories");

        #endregion
    }

    public static void MapSuppliersEndpoints(this WebApplication app)
    {

        #region Endpoint POST /fornecedor

        ///<summary>
        ///Cadastra uma Fornecedor e persiste no banco de dados, se for nulo retorna Status Code 400 BadRequest.
        /// </summary>

        app.MapPost("/fornecedor", async (SupplierInputDto supplierDto, IRepository<Supplier> repository, IMapper mapper) =>
        {
            var supplier = mapper.Map<Supplier>(supplierDto);

            var result = await repository.Create(supplier);

            if (result is null) return BadRequest();

            await repository.SaveChanges();

            return Created($"/fornecedor/{result.Id}", result);
        })
       .Produces(StatusCodes.Status201Created)
       .Produces(StatusCodes.Status400BadRequest)
       .WithTags("Suppliers");

        #endregion

        #region Endpoint GET /fornecedor        

        ///<summary>
        ///Retorna todos os fornecedores cadastrados no banco de dados, se não existir retorna Status Code 204 NoContent
        ///</summary>
        ///
        app.MapGet("/fornecedores", async (IRepository<Supplier> repository, IMapper mapper) =>
        {
            var suppliers = await repository.GetAll();

            var suppliersDto = mapper.Map<IEnumerable<SupplierOutputDto>>(suppliers);

            if (suppliersDto.Count() <= 0) return NoContent();

            return Ok(suppliersDto);

        })
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithTags("Suppliers");

        #endregion

        #region Endpoint DELETE /fornecedor/id

        ///<summary>
        ///Remove um fornecedor pela Id da base de dados
        /// </summary>

        app.MapDelete("/fornecedor/{id:int}", async (int id, IRepository<Supplier> repository) =>
        {
            var result = await repository.GetById(id);

            if (result is null) return BadRequest();

            await repository.Delete(result.Id);
            await repository.SaveChanges();

            return Ok(result);

        })
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .WithTags("Suppliers");

        #endregion


    }

}
