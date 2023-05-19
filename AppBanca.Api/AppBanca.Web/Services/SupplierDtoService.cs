using AppBanca.Models.Domain;
using AppBanca.Models.Dtos;
using AppBanca.Web.Services.Intefaces;

namespace AppBanca.Web.Services;

public class SupplierDtoService : BancaService<SupplierDto>
{
    public SupplierDtoService(HttpClient httpClient, ILogger<BancaService<SupplierDto>> logger) : base(httpClient, logger)
    {
    }
}
