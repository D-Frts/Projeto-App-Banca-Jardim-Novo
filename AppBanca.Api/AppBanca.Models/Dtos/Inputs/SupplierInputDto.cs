namespace AppBanca.Models.Dtos.Inputs;

public class SupplierInputDto
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public decimal Profit { get; set; } = 0.0m;
}
