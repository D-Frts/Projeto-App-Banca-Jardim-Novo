using AppBanca.Models.Domain;
using AppBanca.Models.Dtos;
using AppBanca.Web.Services.Intefaces;

namespace AppBanca.Web.Services;

public class CategoryDtoService : BancaService<CategoryDto>
{
    public CategoryDtoService(HttpClient httpClient, ILogger<BancaService<CategoryDto>> logger) : base(httpClient, logger)
    {
    }
}
