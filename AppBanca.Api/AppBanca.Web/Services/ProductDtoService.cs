using AppBanca.Models.Dtos;
using AppBanca.Web.Services.Intefaces;
using System.Net.Http.Json;

namespace AppBanca.Web.Services;


public class ProductDtoService : BancaService<ProductDto>
{

    public ProductDtoService(HttpClient httpClient, ILogger<BancaService<ProductDto>> logger) : base(httpClient, logger)
    { 
    }



}
