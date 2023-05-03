using AppBanca.Models.Domain;
using AppBanca.Web.Services.Intefaces;

namespace AppBanca.Web.Services;


public class ProductService : BancaService<Product>
{
    public ProductService(HttpClient httpClient, ILogger<BancaService<Product>> logger) : base(httpClient, logger)
    {
    }
}
